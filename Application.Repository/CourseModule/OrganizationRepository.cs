namespace Application.Repository.CourseModule
{
    using Application.Core.CourseModule.OrganizationAggregate;
    using Application.DAL;

    public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public OrganizationRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Constructor
    }
}
