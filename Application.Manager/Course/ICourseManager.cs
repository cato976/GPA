namespace Application.Manager.Course
{
    using System.Collections.Generic;
    using Application.DTO.CourseModule;
    using Application.DTO.OrganizationModule;

    public interface ICourseManager
    {
        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        List<CourseDTO> FindCourses(int pageIndex, int pageCount);

        /// <summary>
        /// Find Course by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CourseDTO FindCourseById(int id);

        /// <summary>
        /// To Delete a Course
        /// </summary>
        /// <param name="courseId"></param>
        void DeleteCourse(int courseId);

        /// <summary>
        /// To Insert a Course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        void InsertCourse(CourseDTO course);
    }
}
