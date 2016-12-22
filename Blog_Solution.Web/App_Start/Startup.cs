using System;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;

[assembly: OwinStartup(typeof(Blog_Solution.Web.App_Start.Startup))]

namespace Blog_Solution.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
                        
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieHttpOnly = true,
                CookieName = "__BLOG_WEB"
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        }

        private static bool IsTrue(string appSettingName)
        {
            return string.Equals(
                ConfigurationManager.AppSettings[appSettingName],
                "true",
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
