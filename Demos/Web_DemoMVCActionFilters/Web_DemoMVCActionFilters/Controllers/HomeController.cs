using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_DemoMVCActionFilters.Models;
using Web_DemoMVCActionFilters.Filters;

namespace Web_DemoMVCActionFilters.Controllers
{
    //[ServiceFilter(typeof(LogActionFilter))] //Local Registration of Filter At Controller level
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ServiceFilter(typeof(LogActionFilter))]//Local Registration of Filter at Action level
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
