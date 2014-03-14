namespace Application.Core.CourseModule.CourseAggregate
{
    /// <summary>
    /// This is the factory for Course creation
    /// </summary>
    public static class CourseFactory
    {
        public static Course CreateCourse(string Name, string number)
        {
            Course objCourse = new Course();

            //Set values for Course
            objCourse.Name = Name;
            objCourse.Number = number;

            return objCourse;
        }
    }
}
