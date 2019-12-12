using CourseApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Web.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
            {
                new Category(){ Name="Kategori 1"},
                new Category(){ Name="Kategori 2"},
                new Category(){ Name="Kategori 3"}
            };

            return View(categories);

        }
    }
}
