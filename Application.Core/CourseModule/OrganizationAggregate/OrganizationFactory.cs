namespace Application.Core.CourseModule.OrganizationAggregate
{
    /// <summary>
    /// This is the factory for Organization creation
    /// </summary>
    public static class OrganizationFactory
    {
        public static Organization CreateOrganization(string name, string address1, string address2, string city, string state, string zipCode)
        {
            Organization objOrganization = new Organization();

            //Set values for Organization
            objOrganization.Name = name;
            objOrganization.Address1 = address1;
            objOrganization.Address2 = address2;
            objOrganization.City = city;
            objOrganization.State = state;
            objOrganization.ZipCode = zipCode;

            return objOrganization;
        }
    }
}
