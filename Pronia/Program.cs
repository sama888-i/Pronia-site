using Microsoft.EntityFrameworkCore;
using Pronia.DataAccess;

namespace Pronia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ProniaDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString ("MSSql" ));
            });
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

            app.MapControllerRoute(name:"default", pattern:"{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
