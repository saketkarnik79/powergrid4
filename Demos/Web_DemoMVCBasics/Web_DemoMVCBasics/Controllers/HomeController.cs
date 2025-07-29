using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using MyLib;

namespace Web_DemoMVCBasics.Controllers
{
    public class HomeController: Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public string? Index()
        //{
        //    return "<h1 style='color:blue;'>Hello, World! Welcome to MVC!</h1>";
        //}

        //public ContentResult Index()
        //{
        //    return Content("<h1 style='color:blue;'>Hello, World! Welcome to MVC!</h1>", "text/html");
        //}

        //public IActionResult Index()
        //{
        //    //return View("Index");
        //    //return View("~/Views/Home/Index.cshtml");

        //    return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"] = $"Hello, World! Welcome to MVC! Dynamic data from controller to view using ViewData at {DateTime.Now}!";
            ViewBag.Message2 = $"Hello, Universe! Welcome to MVC on .NET 8.0! Dynamic data from controller to view using ViewBag at {DateTime.Now}!";

            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"logger: {_configuration["logger"]}");
            //sb.AppendLine($"ComplexConfig.Name: {_configuration["ComplexConfig:Name"]}, ComplexConfig.Value: {_configuration["ComplexConfig:Value"]}");
            //sb.AppendLine($"ComplexConfig.NestedProperty.Name: {_configuration["ComplexConfig:NestedProperty:Name"]}, ComplexConfig.NestedProperty.Value: {_configuration["ComplexConfig:NestedProperty:Value"]}");
            //sb.AppendLine($"ArrayProperty[0].Name: {_configuration["ArrayProperty:0:Name"]}, ArrayProperty[0].Value: {_configuration["ArrayProperty:0:Value"]}");
            //sb.AppendLine($"ArrayProperty[1].Name: {_configuration["ArrayProperty:1:Name"]}, ArrayProperty[1].Value: {_configuration["ArrayProperty:1:Value"]}");
            Class1 cls = new Class1(_configuration);
            ViewBag.ConfigInfo = cls.GetConfig();
            //throw new Exception("This is a test exception to demonstrate global exception handling.");
            return View();
        }

        [HttpGet]
        public IActionResult UserRegistration()
        {
            ViewData["title"] = "User Registration Page";
            ViewBag.UserName = "John Doe";
            ViewBag.Password = "password";
            ViewBag.Email = "john.doe@xyz.com";

            return View();
        }

        [HttpPost]
        public IActionResult UserRegistration(IFormCollection form)
        {
            if (form == null)
            {
                ModelState.AddModelError(string.Empty, "Form data is null.");
                
            }
            if(ModelState.IsValid)
            {
                               // Process the form data
                string userName = form!["UserName"]!;
                string password = form!["Password"]!;
                string email = form!["Email"]!;
                Debug.WriteLine($"UserName: {userName}, Password: {password}, Email: {email}");
                // Here you would typically save the data to a database or perform some action
                ViewData["Message"] = $"User {userName} registered successfully!";
                
            }

            return View();
        }
    }
}
