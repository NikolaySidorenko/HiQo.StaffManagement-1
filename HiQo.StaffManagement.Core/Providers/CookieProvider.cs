using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;

namespace HiQo.StaffManagement.Core.Providers
{
    public class CookieProvider : ICookieProvider
    {
        private const string CookieValue="access-token";

        public string GetToken(HttpActionContext context)
        {
            var cookie = context.Request.Headers.GetCookies(CookieValue).FirstOrDefault();

            return cookie?[CookieValue].Value;
        }

        public CookieHeaderValue GetCookie(HttpActionContext context, string token)
        {
            return new CookieHeaderValue("access-token", token)
            {
                Expires = DateTimeOffset.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesAccessToken"])),
                Domain =  context.Request.RequestUri.Host,
                Path = "/"
            };
        }
    }
}
