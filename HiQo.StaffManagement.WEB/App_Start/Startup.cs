using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(HiQo.StaffManagement.WEB.App_Start.Startup))]

namespace HiQo.StaffManagement.WEB.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(
                clientId: "147873998968-fb2tu4na0p34re8nkv14vpnd80t1mgm1.apps.googleusercontent.com",
                clientSecret: "EA_o1m1e8E7LZ3UBCNRq1EPT");
        }

    }
}