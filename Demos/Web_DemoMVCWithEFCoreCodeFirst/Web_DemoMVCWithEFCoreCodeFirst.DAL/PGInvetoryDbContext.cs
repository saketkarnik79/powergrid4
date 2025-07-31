using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEFCoreCodeFirst.Models;

namespace Web_DemoMVCWithEFCoreCodeFirst.DAL
{
    public class PGInventoryDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PGInventoryDbContext(DbContextOptions<PGInventoryDbContext> options)
            :base(options)
        {
            
        }
    }
}
