using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_DemoMVCConcepts.Models;

namespace Web_DemoMVCConcepts.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product>? products = null;

        static ProductsController()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Gaming Laptop", Price = 150000.0m, Description="Gaming Laptop with Nvidea Graphics card." },
                new Product { Id = 2, Name = "Wireless Mouse", Price = 1500.0m, Description="Ergonomic wireless mouse." },
                new Product { Id = 3, Name = "Mechanical Keyboard", Price = 3000.0m, Description="RGB mechanical keyboard." }
            };
        }

        // GET: ProductsController
        [HttpGet]
        public ActionResult Index()
        {
            //ViewData.Model = products;
            //return View();
            return View(products);
        }

        [HttpGet]
        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = products?.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpGet]
        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (collection == null)
                {
                    return BadRequest("Invalid product data.");
                }
                if (ModelState.IsValid)
                {
                    var newProduct = new Product
                    {
                        Id = products.Max(p => p.Id) + 1,
                        Name = collection["Name"],
                        Description = collection["Description"],
                        Price = decimal.Parse(collection["Price"])
                    };
                    products.Add(newProduct);
                }
                else
                {
                    return View(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = products?.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (collection == null)
                {
                    return BadRequest("Invalid product data.");
                }
                var formId = int.Parse(collection["Id"]);
                if (formId != id)
                {
                    return BadRequest("Product ID mismatch.");
                }
                if (ModelState.IsValid)
                {
                    var product = products?.SingleOrDefault(p => p.Id == id);
                    if (product != null)
                    {
                        product.Name = collection["Name"];
                        product.Description = collection["Description"];
                        product.Price = decimal.Parse(collection["Price"]);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = products?.SingleOrDefault(p => p.Id == id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = products?.SingleOrDefault(p => p.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
