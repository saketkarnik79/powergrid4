using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;

namespace Web_DemoMVCWithEFCoreCodeFirst
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PGInvetoryDbContext>(options=>
                //options.UseInMemoryDatabase("PGInvertory"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
