namespace GPAWeb.Dependency
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Mvc;
    using Application.Common.Logging;
    using Application.Common.Validator;
    using Application.Core.CourseModule.CourseAggregate;
    using Application.Core.CourseModule.OrganizationAggregate;
    using Application.DAL;
    using Application.DAL.Contract;
    using Application.Manager.Course;
    using Application.Manager.Implementation;
    using Application.Manager.Organization;
    using Application.Repository.CourseModule;
    using Castle.Facilities.Logging;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class DependencyConventions : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                  .BasedOn<IController>()
                                  .LifestyleTransient());

            container.Register(

                        Component.For<IQueryableUnitOfWork, UnitOfWork>().ImplementedBy<UnitOfWork>(),

                        Component.For<ICourseRepository, CourseRepository>().ImplementedBy<CourseRepository>(),

                        //Component.For<IAddressRepository, AddressRepository>().ImplementedBy<AddressRepository>(),

                        //Component.For<IAddressTypeRepository, AddressTypeRepository>().ImplementedBy<AddressTypeRepository>(),

                        //Component.For<IPhoneTypeRepository, PhoneTypeRepository>().ImplementedBy<PhoneTypeRepository>(),

                        //Component.For<IPhoneRepository, PhoneRepository>().ImplementedBy<PhoneRepository>(),

                        //Component.For<IProfileAddressRepository, ProfileAddressRepository>().ImplementedBy<ProfileAddressRepository>(),

                        //Component.For<IProfilePhoneRepository, ProfilePhoneRepository>().ImplementedBy<ProfilePhoneRepository>().LifestyleSingleton(),

                        Component.For<ICourseManager>().ImplementedBy<CourseManager>(),
                        Component.For<IOrganizationRepository, OrganizationRepository>().ImplementedBy<OrganizationRepository>(),
                        Component.For<IOrganizationManager>().ImplementedBy<OrganizationManager>(),

                        Classes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient()
                        //AllTypes.FromThisAssembly().BasedOn<IHttpController>().LifestyleTransient()

                        )
                       .AddFacility<LoggingFacility>(f => f.UseLog4Net());

            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
        }
    }
}