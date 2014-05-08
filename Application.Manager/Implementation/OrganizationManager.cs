namespace Application.Manager.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.Common.Logging;
    using Application.DTO.OrganizationModule;
    using Application.Manager.Organization;
    using Application.Manager.Resources;
    using Application.Repository.CourseModule;

    public class OrganizationManager: IOrganizationManager
    {
        #region Global Declearation

        OrganizationRepository _organizationRepository;
        
        #endregion Global Declearation
        
        public OrganizationManager(OrganizationRepository organizationRepository)
        {
            if (organizationRepository == null)
            {
                throw new ArgumentNullException("organizationRepository");
            }

            _organizationRepository = organizationRepository;
        }

        #region IOrganizationManager Members

        public System.Collections.Generic.List<OrganizationDTO> FindOrganizations(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(Messages.warning_InvalidArgumentForFindOrganizations);

            //recover organization in paged fashion
            var organizations = _organizationRepository.GetPaged<DateTime>(pageIndex, pageCount, o => o.Created, false);

            if (organizations != null
                &&
                organizations.Any())
            {
                List<OrganizationDTO> lstOrganizationDTO = new List<OrganizationDTO>();
                foreach (var organization in organizations)
                {
                    lstOrganizationDTO.Add(Conversion.Mapping.OrganizationToOrganizationDTO(organization));
                }
                return lstOrganizationDTO;
            }
            else // no data
                return new List<OrganizationDTO>();
        }

        public OrganizationDTO FindOrganizationById(int id)
        {
            //recover organizations
            var organization = _organizationRepository.Get(id);

            if (organization != null)
            {
                return Conversion.Mapping.OrganizationToOrganizationDTO(organization);
            }
            else //no data
            {
                return new OrganizationDTO();
            }
        }

        public OrganizationDTO FindOrganizationByName(string name)
        {
            //recover organizations
            try
            {
                var organization = _organizationRepository.GetAll().Single(item => item.Name == name);

                if (organization != null)
                {
                    return Conversion.Mapping.OrganizationToOrganizationDTO(organization);
                }
                else //no data
                {
                    return new OrganizationDTO();
                }
            }
            catch 
            {
                return null;
            }
        }

        public void DeleteOrganization(int organizationId)
        {
            var organization = _organizationRepository.Get(organizationId);

            if (organization != null) //if course exist
            {
                _organizationRepository.Remove(organization);

                //commit changes
                _organizationRepository.UnitOfWork.Commit();
            }
            else //the course does not exist, cannot remove
            {
                LoggerFactory.CreateLog().LogWarning(Messages.warning_CannotRemoveNonExistingOrganization);
            }
        }

        public void InsertOrganization(OrganizationDTO organization)
        {
            Core.CourseModule.OrganizationAggregate.Organization org = new Core.CourseModule.OrganizationAggregate.Organization()
            {
                Address1 = organization.Address1,
                Address2 = organization.Address2,
                Campus = organization.Campus,
                City = organization.City,
                Country = organization.Country,
                Name = organization.Name,
                OPEID = organization.OPEID,
                State = organization.State,
                ZipCode = organization.ZipCode
            };
            _organizationRepository.Add(org);
            _organizationRepository.UnitOfWork.Commit();
        }

        #endregion IOrganizationManager Members
    }
}
