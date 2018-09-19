using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace HiQo.StaffManagement.BL.Services
{
    public class TokenHandler : ITokenHandler
    {
        public JWT CreateJwt(string role, string username, int id, string secretKey)
        {
            var expireAccessTokenTime =
                DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesAccessToken"]));

            var expireRefreshTokenTime =
                DateTime.Now.AddMinutes(
                    Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesRefreshToken"]));

            var jwt = new JWT
            {
                AccessToken = CreateAccessToken(role, username, id, expireAccessTokenTime, secretKey),
                RefreshToken = CreateRefreshToken(id, expireRefreshTokenTime, secretKey),
                ExpiresIn = ((DateTimeOffset) expireAccessTokenTime).ToUnixTimeSeconds()
            };

            return jwt;
        }

        public bool IsValidTokenLifetime(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(token);

            var expires = jwt.Payload.Exp;

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(expires)).ToLocalTime();

            return dateTime.CompareTo(DateTime.Now) >= 0;
        }

        public string CreateRefreshToken(int id, DateTime expire, string key)
        {
            var claims = new List<Claim>
            {
                new Claim("userId", id.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expire,
                signingCredentials: GetCredentials(key));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateAccessToken(string role, string username, int id, DateTime expire, string secretKey)
        {
            var claims = new List<Claim>
            {
                new Claim("username", username),
                new Claim("userId", id.ToString()),
                new Claim("role", role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expire,
                signingCredentials: GetCredentials(secretKey));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public SigningCredentials GetCredentials(string key)
        {
            var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            return signCredentials;
        }
    }
}