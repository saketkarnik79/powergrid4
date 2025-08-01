using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;
using Web_DemoMVCWithEFCoreCodeFirst.BizLayer;
using Web_DemoMVCWithEFCoreCodeFirst.UnitOfWork;
using Web_DemoMVCWithEFCoreCodeFirst.Repositories;
using Microsoft.AspNetCore.Identity;
using Web_DemoMVCWithEFCoreCodeFirst.Models;

namespace Web_DemoMVCWithEFCoreCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PGInventoryDbContext>(options=>
                //options.UseInMemoryDatabase("PGInvertory"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PGInventoryDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            builder.Services.AddScoped<IProductBL, ProductBL>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(options => options.AddProfile<MappingProfile>());

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
