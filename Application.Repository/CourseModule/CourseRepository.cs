namespace Application.Repository.CourseModule
{
    using Application.Core.CourseModule.CourseAggregate;
    using Application.DAL;

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public CourseRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Constructor
    }
}
