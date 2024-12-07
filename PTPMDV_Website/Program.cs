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
            
            builder.Services.AddAutoMapper(typeof(AutomapperProfile));
            builder.Services.AddDistributedMemoryCache(); // S? d?ng b? nh? t?m
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Th?i gian t?n t?i c?a session
                options.Cookie.HttpOnly = true; // B?o m?t cookie
                options.Cookie.IsEssential = true; // B?t bu?c cookie cho session ho?t ??ng
            });

            builder.Services.AddHttpClient();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
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
