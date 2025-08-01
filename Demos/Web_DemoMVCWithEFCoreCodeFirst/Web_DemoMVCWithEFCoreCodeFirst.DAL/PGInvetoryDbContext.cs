using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Web_DemoMVCWithEFCoreCodeFirst.Models;

namespace Web_DemoMVCWithEFCoreCodeFirst.DAL
{
    //public class PGInventoryDbContext: DbContext
    public class PGInventoryDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }

        public PGInventoryDbContext(DbContextOptions<PGInventoryDbContext> options)
            :base(options)
        {
            
        }
    }
}
