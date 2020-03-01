using Abp.Application.Services;

namespace UserList
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class UserListAppServiceBase : ApplicationService
    {
        protected UserListAppServiceBase()
        {
            LocalizationSourceName = UserListConsts.LocalizationSourceName;
        }
    }
}