namespace Application.Core.CourseModule.CourseAggregate
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Application.Common;
    using Application.Core.Resources;

    public partial class Course : Entity, IValidatableObject
    {
        #region Constructor

        public Course()
        {

        }

        #endregion Constructor

        #region Properties

        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string UniversalId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public decimal CreditHour { get; set; }
        public decimal ClockHour { get; set; }
        public string Description { get; set; }
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
                validationResults.Add(new ValidationResult(Messages.validation_CourseNameCannotBeNull,
                                                           new string[] { "Name" }));
            }

            //-->Check Number property
            if (String.IsNullOrWhiteSpace(this.Number))
            {
                validationResults.Add(new ValidationResult(Messages.validation_CourseNumberCannotBeBull,
                                                           new string[] { "Number" }));
            }

            return validationResults;
        }

        #endregion IValidatableObject Members
    }
}
