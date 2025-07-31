using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DemoMVCWithEFCoreCodeFirst.Repositories;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;

namespace Web_DemoMVCWithEFCoreCodeFirst.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PGInventoryDbContext _context;
        public IProductRepository Products { get; private set; }

        public UnitOfWork(PGInventoryDbContext context, IProductRepository productRepository)
        {
            _context = context;
            Products = productRepository ;
        }
        

        public async Task<int> CommitChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
