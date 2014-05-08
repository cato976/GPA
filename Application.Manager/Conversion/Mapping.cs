namespace Application.Manager.Conversion
{
    using Application.Core.CourseModule.CourseAggregate;
    using Application.Core.CourseModule.OrganizationAggregate;
    using Application.DTO.CourseModule;
    using Application.DTO.OrganizationModule;

    public static class Mapping
    {
        public static CourseDTO CourseToCourseDTO(Course course)
        {
            CourseDTO objCourseDTO = new CourseDTO()
            {
                Id = course.Id,
                OrganizationId = course.OrganizationId,
                OrganizationName = course.Organization.Name,
                Name = course.Name,
                Description = course.Description,
                Number = course.Number,
                UniversalId = course.UniversalId,
                ClockHour = course.ClockHour,
                CreditHour = course.CreditHour,
                Created = course.Created
            };

            return objCourseDTO;
        }

        public static OrganizationDTO OrganizationToOrganizationDTO(Organization organization)
        {
            OrganizationDTO objOrganizationDTO = new OrganizationDTO()
            {
                Id = organization.Id,
                Address1 = organization.Address1,
                Address2 = organization.Address2,
                Campus = organization.Campus,
                City = organization.City,
                Country = organization.Country,
                Created = organization.Created,
                Name = organization.Name,
                OPEID = organization.OPEID,
                State = organization.State,
                ZipCode = organization.ZipCode
            };

            return objOrganizationDTO;
        }
    }
}
