using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using UserList.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UserList.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UserList.Web.Startup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            //services.AddAbpDbContext<UserListDbContext>(options =>
            //{
            //    DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            //});
            //services.AddAbpDbContext<UserListDbContext>(options =>
            //{
            //    options.DbContextOptions.UseSqlServer(options.ConnectionString);
            //});Configuration

            services.AddDbContext<UserListDbContext>(options => options.UseSqlServer("Server=DESKTOP-7E4TQRP;Database=UserListDb;Trusted_Connection=True;"));


    //        string conString = Microsoft
    //.Extensions
    //.Configuration
    //.ConfigurationExtensions
    //.GetConnectionString(this.Configuration, "Default");

    //        services.AddDbContext<UserListDbContext>(options => options.UseSqlServer(Configuration.GetValue<string>("ConnectionStrings:Default")));


            services.AddTransient<IUserServices, UserServices>();


            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddNewtonsoftJson();

            //Configure Abp and Dependency Injection
            return services.AddAbp<UserListWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=User}/{action=UserList}/{id?}");
            });
        }
    }
}
