namespace Application.DTO.OrganizationModule
{
    using System;

    public class OrganizationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Campus { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string OPEID { get; set; }
        public DateTime Created { get; set; }
    }
}
