using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Web_DemoMVCWithEFCoreCodeFirst.DAL;
using Web_DemoMVCWithEFCoreCodeFirst.BizLayer;
using Web_DemoMVCWithEFCoreCodeFirst.Models;
using AutoMapper;

namespace Web_DemoMVCWithEFCoreCodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly PGInventoryDbContext _context;
        private readonly IProductBL _productBL;

        private readonly IMapper _mapper;

        //public ProductsController(PGInventoryDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //    _context.Database.EnsureCreated(); // Ensure the database is created
        //}
        public ProductsController(IProductBL productBL, IMapper mapper)
        {
            _productBL = productBL;
            _mapper = mapper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            //var productsVMList = _mapper.Map<IEnumerable<ProductViewModel>>(await _context.Products.ToListAsync());

            var productsVMList= _mapper.Map<IEnumerable<ProductViewModel>>(await _productBL.GetProductsAsync());
            return View(productsVMList);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _context.Products
            //    .SingleOrDefaultAsync(m => m.Id == id);

            var product = await _productBL.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            var productVM=_mapper.Map<ProductViewModel>(product);

            return View(productVM);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price")] ProductViewModel productVM)
        {
            var product=_mapper.Map<Product>(productVM);
            if (ModelState.IsValid)
            {
                //_context.Products.Add(product);
                //await _context.SaveChangesAsync();
                await _productBL.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _context.Products.FindAsync(id);
            var product = await _productBL.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var productVM = _mapper.Map<ProductViewModel>(product);
            return View(productVM);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,Price")] ProductViewModel productVM)
        {
            if (id != productVM.Id)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productVM);

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Products.Update(product);
                    //await _context.SaveChangesAsync();
                    await _productBL.UpdateProductAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ProductExists(product.Id))
                    if (!await ProductExistsAsync(product.Id))
                        {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productVM);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _context.Products
            //    .FindAsync(id);
            var product = await _productBL.GetProductByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            var productVM=_mapper.Map<ProductViewModel>(product);
            return View(productVM);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var product = await _context.Products.FindAsync(id);
            var product = await _productBL.GetProductByIdAsync(id);
            if (product != null)
            {
                //_context.Products.Remove(product);
                await _productBL.DeleteProductAsync(id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExistsAsync(long id)
        {
            var products= await _productBL.GetProductsAsync();
            //return _context.Products.Any(e => e.Id == id);
            return products.Any(p=> p.Id == id);
        }
    }
}
