using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MuSe.Web.Data;
using MuSe.Web.Data.Entities;
using MuSe.Web.Data.Repositories;
using MuSe.Web.Helpers;

namespace MuSe.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6; //123456
            })

            .AddEntityFrameworkStores<DataContext>();
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<Seeder>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<ICombosHelper, CombosHelper>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IHelpTypeRepository, HelpTypeRepository>();
            services.AddScoped<IHelpDirectoryRepository, HelpDirectoryRepository>();
            services.AddScoped<IKindOfPlaceRepository, KindOfPlaceRepository>();
            services.AddScoped<IMoodRepository, MoodRepository>();
            services.AddScoped<IReliabilityRepository, ReliabilityRepository>();
            services.AddScoped<IViolentometerRepository, ViolentometerRepository>();
            services.AddScoped<IWomanRepository, WomanRepository>();
            services.AddScoped<IMonitorRepository, MonitorRepository>();
            services.AddScoped<IWomanDiaryRepository, WomanDiaryRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IOwnWomanPlaceRepository, OwnWomanPlaceRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            services.AddControllersWithViews();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/NotAuthorized";
            });

            services.AddControllers().AddNewtonsoftJson(x =>
            x.SerializerSettings.ReferenceLoopHandling =
              Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseRouting();

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
