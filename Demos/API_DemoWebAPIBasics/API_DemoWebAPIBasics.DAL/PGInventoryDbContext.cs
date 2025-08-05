using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API_DemoWebAPIBasics.Models;
using Microsoft.AspNetCore.Identity;

namespace API_DemoWebAPIBasics.DAL
{
    //public class PGInventoryDbContext: DbContext
    public class PGInventoryDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }

        public PGInventoryDbContext(DbContextOptions<PGInventoryDbContext> options):base(options)
        {
               
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().ToTable("tblProducts");
        }
    }
}
