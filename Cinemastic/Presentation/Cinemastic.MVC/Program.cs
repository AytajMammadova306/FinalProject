using Cinemastic.Persistance;
namespace Cinemastic.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.
                AddPersistanceServices(builder.Configuration);

            var app = builder.Build();
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
