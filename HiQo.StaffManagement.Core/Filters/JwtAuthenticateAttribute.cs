using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.Providers;
using Microsoft.IdentityModel.Tokens;

namespace HiQo.StaffManagement.Core.Filters
{
    public sealed class JwtAuthenticateAttribute : AuthorizeAttribute
    {
        public IServiceFactory Factory { get; set; }

        public ICookieProvider Provider { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var service = Factory.Create<IUserService>();
            var token = Provider.GetToken(actionContext);
            if (token == null)
            {
                return false;
            }

            var handler = new JwtSecurityTokenHandler();

            var jwtToken = handler.ReadJwtToken(token);
            var value = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;

            int id;
            if (value == null || !int.TryParse(value,out id))
            {
                return false;
            }

            var secretKey = service.GetById(id).SecurityStamp;
      
            try
            {
                SecurityToken securityToken;
                var claims = handler.ValidateToken(token, GetValidationParameters(secretKey),
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
                ValidIssuer = "HiQo",
                ValidAudience = "HiQo",
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) 
            };
        }
    }
}