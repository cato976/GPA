namespace Application.DAL
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Application.Core.CourseModule.CourseAggregate;
using Application.DAL;

    public class GPAIntializer : DropCreateDatabaseIfModelChanges<UnitOfWork>
    {
        protected override void Seed(UnitOfWork context)
        {
            context.Database.ExecuteSqlCommand(string.Format("ALTER TABLE {0} ADD DEFAULT ({1}) FOR [{2}]", "Courses", "getdate()", "Created"));
            var Courses = new List<Course>{
                new Course{
                    OrganizationId=1,
                    UniversalId="ACC10001",
                    Name = "Introduction to Accounting",
                    Number = "ACC101",
                    CreditHour = 3,
                    ClockHour=0,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Created=DateTime.Now
                },

                new Course{
                     OrganizationId=1,
                    UniversalId="ACC20003",
                    Name = "Applied Accounting",
                    Number = "ACC203",
                    CreditHour = 3,
                    ClockHour=0,
                    Description="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    Created=DateTime.Now
                }
            };

            Courses.ForEach(c => context.Course.Add(c));
        }
    }

    public partial class AddedComputedColumn : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.DemoRecords", "Created", c => c.DateTime());
            AddColumn("dbo.Courses", "Created", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        //public override void Down()
        //{
        //    DropColumn("dbo.DemoRecords", "Created");
        //}
    }
}
