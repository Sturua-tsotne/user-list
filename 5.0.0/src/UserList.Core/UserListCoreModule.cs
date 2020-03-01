using Abp.Modules;
using Abp.Reflection.Extensions;
using UserList.Localization;

namespace UserList
{
    public class UserListCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            UserListLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(UserListCoreModule).GetAssembly());
        }
    }
}