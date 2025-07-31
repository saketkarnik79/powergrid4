using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DemoMVCWithEFCoreCodeFirst.Models;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;

namespace Web_DemoMVCWithEFCoreCodeFirst.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(PGInventoryDbContext context) : base(context)
        {
            
        }
    }
}
