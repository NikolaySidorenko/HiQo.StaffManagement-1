using System.Web.Http.Filters;
using WebApi.AuthenticationFilter;

namespace HiQo.StaffManagement.Core.Filters
{
    public class AuthenticationFilter:AuthenticationFilterAttribute
    {
        public override void OnAuthentication(HttpAuthenticationContext context)
        {
            
        }
    }
}
