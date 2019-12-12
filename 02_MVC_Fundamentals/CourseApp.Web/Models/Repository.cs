using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Web.Models
{
    public static class Repository
    {
        private static List<StudentResponse> students = new List<StudentResponse>();

        public static List<StudentResponse> Students
        {
            get
            {
                return students;
            }
        }

        public static void AddStudent(StudentResponse student)
        {
            students.Add(student);
        }
    }
}
