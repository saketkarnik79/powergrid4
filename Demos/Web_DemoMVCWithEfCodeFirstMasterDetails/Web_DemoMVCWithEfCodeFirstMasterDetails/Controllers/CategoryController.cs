using Microsoft.AspNetCore.Mvc;
using Web_DemoMVCWithEfCodeFirstMasterDetails.DAL;
using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Models;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Validators;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PGInventory3DbContext _context;
        private readonly CategoryValidator _categoryValidator;

        public CategoryController(PGInventory3DbContext context, CategoryValidator categoryValidator)
        {
            _context = context;
            _categoryValidator = categoryValidator;
            _context.Database.EnsureCreated();
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Products)
                .SingleOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult GoToDetails(int? lstCategories)
        {
            if (lstCategories.HasValue)
            {
                int categoryId = lstCategories.Value;
                return RedirectToAction("Details", new { id = categoryId });
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            var state = _categoryValidator.Validate(category);
            if (state.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in state.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View(category);
    }
}
}
