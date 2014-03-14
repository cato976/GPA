namespace Application.DAL
{
    using System;
    using System.Data.Entity;
    using Application.Common.Logging;
    using Application.Core;
    using Application.DAL.Contract;
    using Application.DAL.Resources;
    using System.Linq;


    public class Repository<T> : IRepository<T>
        where T : class
    {
        #region Members

        IQueryableUnitOfWork _UnitOfWork;

        #endregion Members

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            if (unitOfWork == (IUnitOfWork)null)
                throw new ArgumentNullException("unitOfWork");

            _UnitOfWork = unitOfWork;
        }

        #endregion

        #region IRepository<T> Members

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _UnitOfWork;
            }
        }

        public virtual void Add(T item)
        {
            if (item != (T)null)
                GetSet().Add(item); // add new item in this set
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Message.info_CannotAddNullEntity, typeof(T).ToString());
            }
        }

        public virtual void Remove(T item)
        {
            if (item != (T)null)
            {
                //attach item if not exist
                _UnitOfWork.Attach(item);

                //set as "removed"
                GetSet().Remove(item);
            }
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        public virtual void Modify(T item)
        {
            if (item != (T)null)
                _UnitOfWork.SetModified(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        public void TrackItem(T item)
        {
            if (item != (T)null)
                _UnitOfWork.Attach<T>(item);
            else
            {
                LoggerFactory.CreateLog()
                          .LogInfo(Message.info_CannotRemoveNullEntity, typeof(T).ToString());
            }
        }

        public virtual void Merge(T persisted, T current)
        {
            _UnitOfWork.ApplyCurrentValues(persisted, current);
        }

        public virtual T Get(int id)
        {
            if (id != 0)
                return GetSet().Find(id);
            else
                return null;
        }

        public virtual System.Collections.Generic.IEnumerable<T> GetAll()
        {
            return GetSet();
        }

        public virtual System.Collections.Generic.IEnumerable<T> AllMatching(Core.Specification.Course.ISpecification<T> specification)
        {
            return GetSet().Where(specification.SatisfiedBy());
        }

        public virtual System.Collections.Generic.IEnumerable<T> GetPaged<Property>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<System.Func<T, Property>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        public virtual System.Collections.Generic.IEnumerable<T> GetFiltered(System.Linq.Expressions.Expression<System.Func<T, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        #endregion IRepository<T> Members

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_UnitOfWork != null)
            {
                _UnitOfWork.Dispose();
            }
        }

        #endregion IDisposable Members

        #region Private Methods

        IDbSet<T> GetSet()
        {
            return _UnitOfWork.CreateSet<T>();
        }

        #endregion Private Methods
    }
}
