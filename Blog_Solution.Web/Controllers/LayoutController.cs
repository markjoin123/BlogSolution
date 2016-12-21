using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using Blog_Solution.Web.Models.Layout;
using System.Threading.Tasks;
using Blog_Solution.Customers;
using System;

namespace Blog_Solution.Web.Controllers
{
    public class LayoutController : Blog_SolutionControllerBase
    {
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly ILanguageManager _languageManager;
        private readonly CustomerManager _customerManager;

        public LayoutController(
            IUserNavigationManager userNavigationManager, 
            ILocalizationManager localizationManager,
            ILanguageManager languageManager,
            CustomerManager customerManager)
        {
            _userNavigationManager = userNavigationManager;
            _languageManager = languageManager;
            this._customerManager = customerManager;
        }


        [NonAction]
        public async Task<Customers.Dto.Customer> GetCurrentCustomerAsync()
        {
            var loginName = HttpContext.User.Identity.Name;
            var customer = await _customerManager.FindByNameAsync(loginName);
            if (customer == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return customer;

        }

        [ChildActionOnly]
        public PartialViewResult TopMenu(string activeMenu = "")
        {
            var model = new TopMenuViewModel
                        {
                            MainMenu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync("MainMenu", AbpSession.ToUserIdentifier())),
                            ActiveMenuItemName = activeMenu
                        };

            return PartialView("_TopMenu", model);
        }

        [ChildActionOnly]
        public PartialViewResult LanguageSelection()
        {
            var model = new LanguageSelectionViewModel
                        {
                            CurrentLanguage = _languageManager.CurrentLanguage,
                            Languages = _languageManager.GetLanguages()
                        };

            return PartialView("_LanguageSelection", model);
        }

        [ChildActionOnly]
        public PartialViewResult UserMenuOrLoginLink()
        {
            UserMenuOrLoginLinkViewModel model;

            if (AbpSession.UserId.HasValue)
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    CurrentCustomer = AsyncHelper.RunSync(() => GetCurrentCustomerAsync()),
                };
            }
            else
            {
                model = new UserMenuOrLoginLinkViewModel
                {
                    CurrentCustomer = null
                };
            }
            return PartialView("_UserMenuOrLoginLink", model);
        }
    }
}