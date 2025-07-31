using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Models;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails.DAL
{
    public class PGInventory3DbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        public PGInventory3DbContext(DbContextOptions<PGInventory3DbContext> options): base(options)
        {
            
        }
    }
}
