using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using UserList.Web.Startup;
namespace UserList.Web.Tests
{
    [DependsOn(
        typeof(UserListWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class UserListWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserListWebTestModule).GetAssembly());
        }
    }
}