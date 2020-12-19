# dotnet-core-learning-notes

## Fundemental of Dotnet Core

### Viewbag usage
```
ViewBag.UserName = "Sadık";
```

### Model usage

``@model Course``

```
<body>
    <p></p>name:  @Model.Name</p>
    <p>description : @Model.description</p>
    <p>isPublished: @Model.isPublished</p>
</body>
```

To add viewimport from command line

``dotnet new viewimports``

### Asp tags for html elements

```
<form asp-action="apply" method="POST">
    <div asp-validation-summary="All"></div>
    <div class="form-group">
        <label asp-for="Name">Adınız</label>
        <input asp-for="Name" class="form-control">
    </div>
</form>
```
### HttpGet and HttpPost helper tags

```
[HttpGet]
public IActionResult Apply()
{
    return View();
}
```

Post version of same Method:

```
[HttpPost]
public IActionResult Apply(Student student)
{

}
```

### Sample Model Structure

```
[Required(ErrorMessage = "Email adresi giriniz")]
[EmailAddress(ErrorMessage = "Email adresinizi düzgün giriniz")]
public string Email { get; set; }
```

### To validate validity of the model

```
if (ModelState.IsValid)
{
    Repository.AddStudent(student);
    return View("Thanks", student);
}
```

View conjugate:
``<div asp-validation-summary="All"></div>``

### Define static files at startup.cs

```
app.UseStaticFiles(); // wwwroot

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = "/modules"
});
```
Note: ***module*** states folder **node_modules** within project scope. 

### Sample Controller

```
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View()
    }   
}
```

Sample Return Types for Controller

-   View()
-   PartialView()
-   Content()
-   Redirect() => e.g: Redirect("http://www.google.com")
-   RedirectToAction() => e.g: RedirectToAction("FooController","BarAction")
-   Json()
-   File()
-   HttpNotFound()

``return RedirectToAction("List", "Home", new {id=5, sortBy="asc"}) ``

```
app.UseMvc(routes =>
{
    //Searching is from top to bottom. 
    //If one route matches with path, path immediately is performed.
    routes.MapRoute(
        "CoursesByReleased",
        "courses/released/{year}/{month}",
        new {controller="Course",action="ByReleased" },
        new { year=@"\d{4}",month=@"\d{2}"}
    );

    routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
});
```

### Passing Data From Controller To View

```
//FooController.cs
ViewData["course"] = sth;

//FooView.cshtml
@(((Course)ViewData["course"]).Name)
```

With ***ViewBag***

```
//FooController.cs
ViewData.count = sth;

//FooView.cshtml
@ViewBag.count
```

### Pass data via ViewModel

Create folder **ViewModels** at project root level

```
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
```

### Define variable at razor

```
@{
    var className = Model.Students.Count > 2 "popular" : null;
}

//...

<h1 class="@classname">Sth sth</h1>
```

### Partial View

Folder hierarchy of PartialView:

-   Views
    -   Foo
    -   Bar
    -   Shared
        -   _Menu.cshtml


### To use Partial view at html
(Firstly, you can bind Model to View, then this model may be bound to partial view)

``@Html.Partial("_Menu",Model)``


### ViewComponents 

Folder ***ViewComponents** is composed at project root level.

For example: ``MenuViewComponent.cs``

```
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
```

### Define layout page and section defining

``_Layout.cshtml`` is defined under folder Shared.

Sample layout:
```
    @model ProductsCategoriesViewModel

    @{
    Layout = null;
    }
    <div id="header">
        Layout 1
    </div>

    @RenderSection("TopBanner",false)  

    @await Component.InvokeAsync("Menu")

    <div id="content">
        @RenderBody()
    </div>

    @if (IsSectionDefined("BottomBanner"))
    {
        @RenderSection("BottomBanner")
    }
    else
    {
        <div class="banner defaultbanner">
            Default Banner
        </div>
    }

    <div id="footer">
        Footer
    </div>
```

Then, you can pages simply.

```
About.cshtml
//...
<h1>About us</h1>
```

You can change defined layout

```
    @{
        Layout= "~/Views/Shared/_Layout2.cshtml"
    }
```
Also, you can disable layout for specific pages:

```
    @{
        Layout= null
    }
```

Moreover, default layout page can be assigned at File **_ViewStart.cs.html**

```
@{
    Layout="~/Views/Shared/_Layout.cshtml"
}
```

### Sections

To send section optionally:

``@RenderSection("BottomBanner", false)``;

Second parameter should be false for optionality

``IsSectionDefined can be used to check existance of sections``



