using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GPAWeb.Models
{
    public class CourseModel
    {
       // public CourseModel() { }

        public int CourseId { get; set; }
        public int OrganizationId { get; set; }
        public string UniversalId { get; set; }
        public string Name { get; set; }
        public string CourseNumber { get; set; }
        public decimal CreditHour { get; set; }
        public decimal ClockHour { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}