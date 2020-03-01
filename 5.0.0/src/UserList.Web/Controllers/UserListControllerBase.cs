using Abp.AspNetCore.Mvc.Controllers;

namespace UserList.Web.Controllers
{
    public abstract class UserListControllerBase: AbpController
    {
        protected UserListControllerBase()
        {
            LocalizationSourceName = UserListConsts.LocalizationSourceName;
        }
    }
}