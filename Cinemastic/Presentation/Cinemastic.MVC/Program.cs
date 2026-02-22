using Cinemastic.Application;
using Cinemastic.Domain.Entities;
using Cinemastic.Infrastructure;
using Cinemastic.Persistance;
using Microsoft.AspNetCore.Identity;
using System;
namespace Cinemastic.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services
                .AddPersistanceServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration)
                .AddApplicationServices();



            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseStaticFiles();

            app.MapControllerRoute(
                "defualt",
                "{area:exists}/{controller=home}/{action=index}/{id?}");

            app.MapControllerRoute(
                "defualt",
                "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}
