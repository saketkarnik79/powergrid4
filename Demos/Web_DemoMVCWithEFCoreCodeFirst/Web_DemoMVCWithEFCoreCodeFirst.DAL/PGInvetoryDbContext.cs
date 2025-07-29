using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEFCoreCodeFirst.Models;

namespace Web_DemoMVCWithEFCoreCodeFirst.DAL
{
    public class PGInvetoryDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PGInvetoryDbContext(DbContextOptions<PGInvetoryDbContext> options)
            :base(options)
        {
            
        }
    }
}
