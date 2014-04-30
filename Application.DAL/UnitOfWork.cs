namespace Application.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Application.Core.CourseModule.CourseAggregate;
    using Application.Core.CourseModule.OrganizationAggregate;
    using Application.DAL.Contract;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class UnitOfWork : DbContext, IQueryableUnitOfWork
    {
        #region Constructor

        public UnitOfWork()
            : base("name=Application.DAL.UnitOfWork")
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        #endregion Constructor

        #region IDbSet Members
        
        IDbSet<Course> _course;
        public IDbSet<Course> Course
        {
            get
            {
                if (_course == null)
                {
                    _course = base.Set<Course>();
                }

                return _course;
            }
        }

        IDbSet<Organization> _organization;
        public IDbSet<Organization> Organization
        {
            get
            {
                if (_organization == null)
                {
                    _organization = base.Set<Organization>();
                }

                return _organization;
            }

        }

        #endregion IDbSet Members

        #region IQueryableUnitOfWork Members

        public DbSet<T> CreateSet<T>() where T : class
        {
            return base.Set<T>();
        }

        public void Attach<T>(T item) where T : class
        {
            //attach and set as unchanged
            base.Entry<T>(item).State = EntityState.Unchanged;
        }

        public void SetModified<T>(T item) where T : class
        {
            //this operation also attach item in object state manager
            base.Entry<T>(item).State = EntityState.Modified;
        }

        public void ApplyCurrentValues<T>(T original, T current) where T : class
        {
            //if it is not attached, attach original and set current values
            base.Entry<T>(original).CurrentValues.SetValues(current);
        }

        #endregion IQueryableUnitOfWork Members

        #region IUnitOfWork Members

        public void Commit()
        {
            base.SaveChanges();
        }

        public void CommitAndRefreshChanges()
        {
            bool saveFailed = false;

            do
            {
                try
                {
                    base.SaveChanges();

                    saveFailed = false;

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    ex.Entries.ToList()
                              .ForEach(entry =>
                              {
                                  entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                              });

                }
            } while (saveFailed);
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion IQueryableUnitOfWork Members

        #region ISql Members

        public System.Collections.Generic.IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters)
        {
            return base.Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return base.Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        #endregion ISql Members
    }

    //public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<UnitOfWork>
    //{
    //    protected override void Seed(UnitOfWork context)
    //    {
    //        context.Seed(context);

    //        base.Seed(context);
    //    }
    //}

    //public class CreateInitializer : CreateDatabaseIfNotExists<UnitOfWork>
    //{
    //    protected override void Seed(UnitOfWork context)
    //    {
    //        context.Seed(context);

    //        base.Seed(context);
    //    }
    //}
}
