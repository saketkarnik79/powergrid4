using Web_DemoMVCWithEfCodeFirstMasterDetails.Models;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(PGInventory3DbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();
            // Check if any categories exist
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }
            
            // Seed data
            var categories = new[]
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Books" },
                new Category { Name = "Clothing" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }
            var products = new[]
            {
                new Product { Name = "Smartphone", Price = 699.99m, CategoryId = categories[0].CategoryId },
                new Product { Name = "Laptop", Price = 999.99m, CategoryId = categories[0].CategoryId },
                new Product { Name = "Novel", Price = 19.99m, CategoryId = categories[1].CategoryId },
                new Product { Name = "T-Shirt", Price = 14.99m, CategoryId = categories[2].CategoryId }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
