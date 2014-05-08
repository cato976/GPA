namespace Application.Manager.Organization
{
    using System.Collections.Generic;
    using Application.DTO.OrganizationModule;

    public interface IOrganizationManager
    {
        /// <summary>
        /// Get all Organizations
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageCount"></param>
        /// <returns>List<OrganizationDTO></returns>
        List<OrganizationDTO> FindOrganizations(int pageIndex, int pageCount);

        /// <summary>
        /// Find Organization by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OrganizationDTO</returns>
        OrganizationDTO FindOrganizationById(int id);

        /// <summary>
        /// Find Organization by Name
        /// </summary>
        /// <param name="id"></param>
        /// <returns>OrganizationDTO</returns>
        OrganizationDTO FindOrganizationByName(string name);

        /// <summary>
        /// To Delete a Organization
        /// </summary>
        /// <param name="organziationId"></param>
        void DeleteOrganization(int organizationId);

        /// <summary>
        /// To Insert a Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        void InsertOrganization(OrganizationDTO organization);
    }
}
