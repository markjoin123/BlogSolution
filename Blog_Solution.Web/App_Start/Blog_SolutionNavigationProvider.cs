using Abp.Application.Navigation;
using Abp.Localization;

namespace Blog_Solution.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class Blog_SolutionNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Customer",
                        new LocalizableString("Customer", Blog_SolutionConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-home"
                        ).AddItem(
                        new MenuItemDefinition(
                            "Customer.List",
                            new LocalizableString("Customer.List", Blog_SolutionConsts.LocalizationSourceName),
                            url: "/Customer/List",
                            icon: "fa-dot-circle-o")
                        ).AddItem(
                        new MenuItemDefinition(
                            "CustomerRole.List",
                            new LocalizableString("CustomerRole.List", Blog_SolutionConsts.LocalizationSourceName),
                            url: "/CustomerRole/List",
                            icon: "fa-dot-circle-o")
                        )
                )
                 .AddItem(
                    new MenuItemDefinition(
                        "Catalog",
                        new LocalizableString("Catalog", Blog_SolutionConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-home"
                        ).AddItem(
                        new MenuItemDefinition(
                            "Catalog.List",
                            new LocalizableString("Catalog.List", Blog_SolutionConsts.LocalizationSourceName),
                            url: "/Category/List",
                            icon: "fa-dot-circle-o")
                        ).AddItem(
                        new MenuItemDefinition(
                            "Blog.List",
                            new LocalizableString("Blog.List", Blog_SolutionConsts.LocalizationSourceName),
                            url: "/Blog/List",
                            icon: "fa-dot-circle-o")
                        )
                );
        }
    }
}
