namespace Application.Core.CourseModule.OrganizationAggregate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Application.Common;
    using Application.Core.Resources;

    public partial class Organization : Entity, IValidatableObject
    {
        #region Constructor

        public Organization()
        {

        }

        #endregion Constructor

        #region Properties

        [Key]
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
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public System.DateTime Created { get; set; }

        #endregion Properties

        #region IValidatableObject Members

        /// <summary>
        /// This will validate entity for all  the conditions
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            //-->Check Name property
            if (String.IsNullOrWhiteSpace(this.Name))
            {
                validationResults.Add(new ValidationResult(Messages.validation_OrganizationNameCannotBeNull,
                                                           new string[] { "Name" }));
            }

            return validationResults;
        }

        #endregion IValidatableObject Members
    }
}
