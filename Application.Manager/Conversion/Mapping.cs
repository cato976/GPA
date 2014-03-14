namespace Application.Manager.Conversion
{
    using Application.Core.CourseModule.CourseAggregate;
    using Application.DTO.CourseModule;

    public static class Mapping
    {
        public static CourseDTO CourseToCourseDTO(Course course)
        {
            CourseDTO objProfileDTO = new CourseDTO();
            objProfileDTO.Id = course.Id;
            objProfileDTO.Name = course.Name;
            objProfileDTO.Description = course.Description;
            objProfileDTO.OrganizationId = course.OrganizationId;
            objProfileDTO.Number = course.Number;
            objProfileDTO.UniversalId = course.UniversalId;
            objProfileDTO.ClockHour = course.ClockHour;
            objProfileDTO.CreditHour = course.CreditHour;
            objProfileDTO.Created = course.Created;

            return objProfileDTO;
        }
    }
}
