using Microsoft.EntityFrameworkCore;
using Web_DemoMVCWithEfCodeFirstMasterDetails.DAL;
using Web_DemoMVCWithEfCodeFirstMasterDetails.Validators;

namespace Web_DemoMVCWithEfCodeFirstMasterDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddDbContext<PGInventory3DbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddScoped<CategoryValidator>();
            builder.Services.AddScoped<ProductValidator>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //DbInitializer.Initialize(app.Services.GetRequiredService<PGInventory3DbContext>());
            DbInitializer.Initialize(app.Services.CreateScope().ServiceProvider.GetRequiredService<PGInventory3DbContext>());
            app.Run();
            // Initialize the database
            
            //DbInitializer.Initialize(app.Services.CreateScope().ServiceProvider.GetRequiredService<PGInventory3DbContext>());
        }
    }
}
