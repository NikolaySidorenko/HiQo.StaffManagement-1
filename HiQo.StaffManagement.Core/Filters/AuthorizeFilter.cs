using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace HiQo.StaffManagement.Core.Filters
{
    public sealed class AuthorizeFilter: AuthorizeAttribute
    {
        public string Roles { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var cookie = actionContext.Request.Headers.GetCookies("access_token").FirstOrDefault();

            if (cookie == null)
            {
                actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                base.OnAuthorization(actionContext);
            }

            if (!HasAccess(cookie["access_token"].Value))
            {
                actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                base.OnAuthorization(actionContext);
            }
        }

        private bool HasAccess(string token)
        {
            try
            {
                char[] separator={','};
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                return Roles.Split(separator,StringSplitOptions.RemoveEmptyEntries).Contains(role);
            }
            catch (ArgumentException exception)
            {
                //TODO: log exception
                return false;
            }
        }
    }
}

    

