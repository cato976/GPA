namespace Application.Manager.Conversion
{
    using Application.Core.CourseModule.CourseAggregate;
    using Application.Core.CourseModule.OrganizationAggregate;
    using Application.DTO.CourseModule;

    public static class Mapping
    {
        public static CourseDTO CourseToCourseDTO(Course course)
        {
            CourseDTO objCourseDTO = new CourseDTO();
            objCourseDTO.Id = course.Id;
            objCourseDTO.OrganizationId = course.OrganizationId;
            objCourseDTO.OrganizationName = course.Organization.Name;
            objCourseDTO.Name = course.Name;
            objCourseDTO.Description = course.Description;
            objCourseDTO.OrganizationId = course.OrganizationId;
            objCourseDTO.Number = course.Number;
            objCourseDTO.UniversalId = course.UniversalId;
            objCourseDTO.ClockHour = course.ClockHour;
            objCourseDTO.CreditHour = course.CreditHour;
            objCourseDTO.Created = course.Created;

            return objCourseDTO;
        }
    }
}
