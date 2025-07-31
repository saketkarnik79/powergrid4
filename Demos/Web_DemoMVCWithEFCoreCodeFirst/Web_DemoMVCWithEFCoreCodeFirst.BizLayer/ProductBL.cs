using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DemoMVCWithEFCoreCodeFirst.Models;
//using Web_DemoMVCWithEFCoreCodeFirst.DAL;
using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEFCoreCodeFirst.UnitOfWork;

namespace Web_DemoMVCWithEFCoreCodeFirst.BizLayer
{
    public class ProductBL : IProductBL
    {
        //private readonly PGInventoryDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public ProductBL(PGInventoryDbContext context)
        //{
        //    _context = context;
        //    _context.Database.EnsureCreated();
        //    //_context.Database.Migrate();
        //    _context.Database.SetCommandTimeout(TimeSpan.FromMinutes(1));
        //}

        public ProductBL(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddProductAsync(Product product)
        {
            //Add actual business logic here if needed

            //_context.Products.Add(product);
            //await _context.SaveChangesAsync();

            _unitOfWork.Products.Add(product);
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task DeleteProductAsync(long id)
        {
            var product = await GetProductByIdAsync(id);
            // Add actual business logic here if needed
            if (product != null)
            {
                //_context.Products.Remove(product);
                await _unitOfWork.Products.DeleteAsync(id);
            }
            //await _context.SaveChangesAsync();
            await _unitOfWork.CommitChangesAsync();
        }

        public async Task< Product?> GetProductByIdAsync(long id)
        {
            //var product = await _context.Products.SingleOrDefaultAsync(m => m.Id == id);
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            // Add actual business logic here if needed
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            //var products = await _context.Products.ToListAsync();
            var products = await _unitOfWork.Products.GetAllAsync();
            //Add actual busness logic here if needed
            return products;    
        }

        public async Task UpdateProductAsync(Product product)
        {
            // Add actual business logic here if needed
            //_context.Products.Update(product);
            _unitOfWork.Products.Update(product);
            //await _context.SaveChangesAsync();
            await _unitOfWork.CommitChangesAsync();
        }
    }
}
