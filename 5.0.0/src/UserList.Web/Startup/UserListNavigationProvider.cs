using Abp.Application.Navigation;
using Abp.Localization;

namespace UserList.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class UserListNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "User/Index",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.UserList,
                        L("About"),
                        url: "User/UserList",
                        icon: "fa fa-info"
                        )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, UserListConsts.LocalizationSourceName);
        }
    }
}
