namespace Application.Manager.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Common.Logging;
    using Application.DTO.CourseModule;
    using Application.Manager.Course;
    using Application.Manager.Resources;
    using Application.Repository.CourseModule;

    public class CourseManager : ICourseManager
    {
        #region Global Declearation

        CourseRepository _courseRepository;

        #endregion Global Declearation

         #region Constructor

        public CourseManager(CourseRepository courseRepository)
        {
            if (courseRepository == null)
                throw new ArgumentNullException("courseRepository");

            _courseRepository = courseRepository;
        }

        #endregion Constructor

        #region Interface Implementation

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public List<CourseDTO> FindCourses(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentForFindCourses);

            //recover courses in paged fashion
            var courses = _courseRepository.GetPaged<DateTime>(pageIndex, pageCount, o => o.Created, false);

            if (courses != null
                &&
                courses.Any())
            {
                List<CourseDTO> lstCourseDTO = new List<CourseDTO>();
                foreach (var course in courses)
                {
                    lstCourseDTO.Add(Conversion.Mapping.CourseToCourseDTO(course));
                }
                return lstCourseDTO;
            }
            else // no data
                return new List<CourseDTO>();
        }

        /// <summary>
        /// Find Course by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CourseDTO FindCourseById(int id)
        {

            //recover orders
            var course = _courseRepository.Get(id);

            if (course != null)
            {
                return Conversion.Mapping.CourseToCourseDTO(course);
            }
            else //no data
                return new CourseDTO();

        }


        /// <summary>
        /// Delete course
        /// </summary>
        /// <param name="courseId"></param>
        public void DeleteCourse(int courseId)
        {
            var course = _courseRepository.Get(courseId);

            if (course != null) //if course exist
            {
                _courseRepository.Remove(course);

                //commit changes
                _courseRepository.UnitOfWork.Commit();
            }
            else //the customer not exist, cannot remove
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingCourse);
        }

        #endregion
    }
}
