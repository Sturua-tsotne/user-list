using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace UserList.EntityFrameworkCore
{
    [DependsOn(
        typeof(UserListCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class UserListEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserListEntityFrameworkCoreModule).GetAssembly());
        }
    }
}