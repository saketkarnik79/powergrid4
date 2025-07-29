using Microsoft.AspNetCore.Mvc;

namespace Web_DemoMVCBasics.Controllers
{
    [Route("mvc/product")]
    public class ProductsController : Controller
    {
        [HttpGet("")]
        //[Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("details/{id:int}")]
        public IActionResult Details(int id)
        {
            // Simulate fetching product details
            ViewBag.ProductId = id;
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] string name)
        {

            // Simulate saving the product
            // In a real application, you would save the product to a database

            return RedirectToAction("Index");
        }
    }
}
