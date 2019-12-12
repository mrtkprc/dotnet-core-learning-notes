using CourseApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Web.ViewModels
{
    public class CourseStudentsViewModel
    {
        public Course Course { get; set; }
        public List<Student> Students { get; set; }
    }
}
