using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseApp.Web.Models;
using CourseApp.Web.ViewModels;

namespace CourseApp.Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var kurs = new Course() { Id = 1, Name = "Komple Uygulamalı Web Geliştirme Eğitimi" };

            var ogrenciler = new List<Student>()
            {
                new Student() { Name = "Ahmet" },
                new Student() { Name = "Ayşe" },
                new Student() { Name = "Mehmet" },
                new Student() { Name = "Çınar" }
            };

            var viewmodel = new CourseStudentsViewModel();

            viewmodel.Course = kurs;
            viewmodel.Students = ogrenciler;
            
            return View(viewmodel);
        }

    }
}