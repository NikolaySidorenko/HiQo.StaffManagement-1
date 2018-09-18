using System;
using System.Collections.Generic;
using System.Configuration;
using System.Security.Claims;
using System.Text;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HiQo.StaffManagement.BL.Services
{
    public class TokenHandler : ITokenHandler
    {
        public JWT CreateJwt(string role, string username, int id)
        {
            var expireAccessTokenTime =
                DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesAccessToken"]));

            var expireRefreshTokenTime = 
                DateTime.Now.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesRefreshToken"]));

            var jwt = new JWT
            {
                AccessToken = CreateAccessToken(role, username, id, expireAccessTokenTime),
                RefreshToken = CreateRefreshToken(id, expireRefreshTokenTime),
                ExpiresIn = expireAccessTokenTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds
            };

            return jwt;
        }

        public string CreateRefreshToken(int id, DateTime expire)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expire,
                signingCredentials: GetCredentials());

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string CreateAccessToken(string role, string username, int id, DateTime expire)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expire,
                signingCredentials: GetCredentials());

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public SigningCredentials GetCredentials()
        {
            var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["secretkey"])), 
                SecurityAlgorithms.HmacSha256Signature);

            return signCredentials;
        }
    }
}