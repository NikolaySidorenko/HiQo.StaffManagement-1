using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;

namespace HiQo.StaffManagement.Core.Providers
{
    public interface ICookieProvider
    {
        string GetToken(HttpActionContext context);

        CookieHeaderValue GetCookie(HttpActionContext context, string token);
    }
}
