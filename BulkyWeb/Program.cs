using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>
                (x=>x.UseSqlServer
                (builder.Configuration.GetConnectionString
                ("DefaultConection")
                )
                );

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
                pattern: "{controller=Home}/{action=Index}/{id?}");//Id? is represents the optional
                //The Url Pattern for Routing is considered after the domain name
                //ex:https://localhost:77777/Category/index/3
                //   https://localhost:77777/{controller}/{action}/{id}
            app.Run();
        }
    }
}
