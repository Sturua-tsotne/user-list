using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UserList.Configuration;
using UserList.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace UserList.Web.Startup
{
    [DependsOn(
        typeof(UserListApplicationModule), 
        typeof(UserListEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class UserListWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public UserListWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(UserListConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<UserListNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(UserListApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserListWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(UserListWebModule).Assembly);
        }
    }
}