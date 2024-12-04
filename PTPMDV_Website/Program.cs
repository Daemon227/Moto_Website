using Microsoft.EntityFrameworkCore;
using PTPMDV_Website.Data;
using PTPMDV_Website.Helper;

namespace PTPMDV_Website
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MotoWebsiteContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("OurWebsite"));
            });
            //https://docs.automapper.org/en/stable/Dependency-injection.html
            builder.Services.AddAutoMapper(typeof(AutomapperProfile));

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
