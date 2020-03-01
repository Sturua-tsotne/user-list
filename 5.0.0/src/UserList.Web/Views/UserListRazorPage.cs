using Abp.AspNetCore.Mvc.Views;

namespace UserList.Web.Views
{
    public abstract class UserListRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected UserListRazorPage()
        {
            LocalizationSourceName = UserListConsts.LocalizationSourceName;
        }
    }
}
