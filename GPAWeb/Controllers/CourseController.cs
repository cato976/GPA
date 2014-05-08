namespace GPAWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using Application.Manager.Course;
    using Application.Manager.Organization;

    public class CourseController : Controller
    {

        #region Global declaration

        private readonly ICourseManager _courseManager;
        private readonly IOrganizationManager _organizationManager;

        //private readonly IOrganizationManager _organizationManager;

        #endregion Global declaration
        
        #region Constructor

        public CourseController(ICourseManager courseManager, IOrganizationManager organizationManager)
        {
            _courseManager = courseManager;
            _organizationManager = organizationManager;
        }

        //public CourseController()
        //{
        //}

        #endregion Constructor

        //
        // GET: /Course/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get all Course information
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllCourses()
        {
            var courses = _courseManager.FindCourses(0, 20).AsQueryable();
            return this.Json(courses, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get all Organization information
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllOrganizations()
        {
            var organizations = _organizationManager.FindOrganizations(0, 20).AsQueryable();
            return this.Json(organizations, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult CreateEdit()
        //{
        //    return View();
        //}

        /// <summary>
        /// Delete an existing course
        /// </summary>
        /// <param name="id"></param>
        [System.Web.Http.HttpDelete]
        //[System.Web.Http.HttpPost]
        public void DeleteCourse(int id)
        {
            try
            {
                if (id != 0)
                {
                    _courseManager.DeleteCourse(id);
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            //return View();

            //return RedirectToAction("Index");
        }

        [System.Web.Http.HttpPost]
        
        public ActionResult CreateEdit(Models.CourseModel course)
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public JsonResult SaveCourse(Models.CourseModel course)
        {
            if (course != null)
            {
                Application.DTO.OrganizationModule.OrganizationDTO org = _organizationManager.FindOrganizationByName(course.OrganizationName);
                if (org == null || org.Name != course.OrganizationName)
                {
                    // create a new organization
                    org = new Application.DTO.OrganizationModule.OrganizationDTO();
                    org.Name = course.OrganizationName;
                    _organizationManager.InsertOrganization(org);
                    org = _organizationManager.FindOrganizationByName(course.OrganizationName);
                }

                Application.DTO.CourseModule.CourseDTO cour = new Application.DTO.CourseModule.CourseDTO()
                {
                    OrganizationId = org.Id,
                    UniversalId = course.UniversalId,
                    Name = course.Name,
                    Number = course.CourseNumber,
                    ClockHour = course.ClockHour,
                    CreditHour = course.CreditHour,
                    Description = course.Description,

                };
                _courseManager.InsertCourse(cour);
            }

            return Json("Success!!");
        }

        public ActionResult Import()
        {
            return View();
        }

        public ActionResult ImportExcel()
        {


            if (Request.Files["CourseUpload"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["CourseUpload"].FileName);
                string path1 = string.Format("{0}/{1}", Server.MapPath("~/Content/UploadedFolder"), Request.Files["CourseUpload"].FileName);
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }

                Request.Files["CourseUpload"].SaveAs(path1);
                //string sqlConnectionString = ConnectionManager @"Data Source=LEEDHAR2-PC\SQLEXPRESS;Database=Leedhar_Import;Trusted_Connection=true;Persist Security Info=True";
                string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Application.DAL.UnitOfWork"].ConnectionString;


                //Create connection string to Excel work book
                string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties=Excel 12.0;Persist Security Info=False";
                //Create Connection to Excel work book
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                //Create OleDbCommand to fetch data from Excel
                OleDbCommand cmd = new OleDbCommand("Select [Id],[OrganizationId],[UniversalId],[Name],[Number],[CreditHour],[ClockHour],[Description] from [Sheet1$]", excelConnection);

                excelConnection.Open();
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();

                SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
                //Give your Destination table name
                sqlBulk.DestinationTableName = "Courses";
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();

                // SQL Server Connection String


            }

            return RedirectToAction("Index");
        }
    }
}
