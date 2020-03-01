using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace UserList
{
    [DependsOn(
        typeof(UserListCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class UserListApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserListApplicationModule).GetAssembly());
        }
    }
}