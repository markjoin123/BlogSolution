using Blog_Solution.Customers.Dto;

namespace Blog_Solution.Web.Models.Layout
{
    public class UserMenuOrLoginLinkViewModel
    {
        public Customer CurrentCustomer { get; set; }

        public string GetShownLoginName()
        {
            var userName = "<span id=\"HeaderCurrentUserName\">" + CurrentCustomer.UserName + "</span>";

            return userName;
        }
    }
}