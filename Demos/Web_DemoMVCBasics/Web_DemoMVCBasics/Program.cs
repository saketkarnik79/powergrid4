using Web_DemoMVCBasics.Middlewares;

namespace Web_DemoMVCBasics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            var config = app.Configuration;
            Console.WriteLine($"logger: {config["logger"]}");
            Console.WriteLine($"ComplexConfig.Name: {config["ComplexConfig:Name"]}, ComplexConfig.Value: {config["ComplexConfig:Value"]}");
            Console.WriteLine($"ComplexConfig.NestedProperty.Name: {config["ComplexConfig:NestedProperty:Name"]}, ComplexConfig.NestedProperty.Value: {config["ComplexConfig:NestedProperty:Value"]}");
            Console.WriteLine($"ArrayProperty[0].Name: {config["ArrayProperty:0:Name"]}, ArrayProperty[0].Value: {config["ArrayProperty:0:Value"]}");
            Console.WriteLine($"ArrayProperty[1].Name: {config["ArrayProperty:1:Name"]}, ArrayProperty[1].Value: {config["ArrayProperty:1:Value"]}");

            Console.WriteLine($"logger: {config["logger"]}");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMiddleware<GlobalExceptionMiddleware>();
            app.UseGlobalException();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
