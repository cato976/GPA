namespace Application.DTO.CourseModule
{
    using System;

    public class CourseDTO
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string UniversalId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal CreditHour { get; set; }
        public decimal ClockHour { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
