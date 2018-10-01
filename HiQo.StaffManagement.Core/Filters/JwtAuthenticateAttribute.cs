using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace HiQo.StaffManagement.Core.Filters
{
    public sealed class JwtAuthenticateAttribute : AuthorizeAttribute
    {
        public IServiceFactory Factory { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var service = Factory.Create<IUserService>();
            var cookie = actionContext.Request.Headers.GetCookies("access_token").FirstOrDefault();
            if (cookie == null)
            {
                return false;
            }

            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadJwtToken(cookie["access_token"].Value);
            var value = token.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            if (value == null)
            {
                return false;
            }

            var secretKey = service.GetById(int.Parse(value)).SecurityStamp;

            SecurityToken securityToken;
            try
            {
                var claims = handler.ValidateToken(cookie["access_token"].Value, GetValidationParameters(secretKey),
                    out securityToken);
            }
            catch (SecurityTokenValidationException)
            {
                return false;
            }

            return true;
        }


        private static TokenValidationParameters GetValidationParameters(string key)
        {
            return new TokenValidationParameters
            {
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) 
            };
        }
    }
}