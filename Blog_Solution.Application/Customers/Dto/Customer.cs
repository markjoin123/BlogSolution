using Abp.AutoMapper;
using Blog_Solution.Common;
using Microsoft.AspNet.Identity;

namespace Blog_Solution.Customers.Dto
{
    [AutoMap(typeof(Blog_Solution.Domain.Customers.Customer))]
    public class Customer : Blog_Solution.Domain.Customers.Customer, IUser<int>
    {

        public Customer()
        {
            this.PasswordSalt = CommonHelper.GenerateRandomDigitCode(6);
        }

        public string UserName
        {
            get
            {
                return this.LoginName;
            }

            set
            {
                this.UserName = LoginName;
            }
        }
    }
}
