using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DemoWebAPIBasics.DAL
{
    public class PGInventoryDbContextFactory : IDesignTimeDbContextFactory<PGInventoryDbContext>
    {
        public PGInventoryDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<PGInventoryDbContext>();
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MsSqlLocalDb;Database=PGInventory5;Trusted_Connection=True;Trust Server Certificate=True;MultipleActiveResultSets=True;");

            return new PGInventoryDbContext(optionsBuilder.Options);
        }
    }
}
