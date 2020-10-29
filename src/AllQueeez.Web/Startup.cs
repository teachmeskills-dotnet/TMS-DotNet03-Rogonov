using AllQueez.BLL.Interfaces;
using AllQueez.BLL.Managers;
using AllQueez.BLL.Repository;
using AllQueez.DAL.Context;
using AllQueez.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AllQueez.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Repository pattern (Generic)
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Managers
            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IThemeManager, ThemeManager>();
            services.AddScoped<IGameManager, GameManager>();
            services.AddScoped<IRoundManager, RoundManager>();
            services.AddScoped<IQuestionManager, QuestionManager>();

            // Database context
            services.AddDbContext<AllQueezContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AllQueezConnection")));

            // ASP.NET Core Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AllQueezContext>();

            // Microsoft services
            services.AddControllersWithViews();
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "AllQueez.Cookie";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
