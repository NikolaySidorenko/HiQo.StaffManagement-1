using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace HiQo.StaffManagement.BL.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IRepository _repository;
        private readonly IUserService _userService;

        public TokenHandler(IUserService userService, IRepository repository)
        {
            _userService = userService;
            _repository = repository;
        }

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

        public JWT UpdateAccessAndRefreshToken(string refreshToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(refreshToken);
            var isTokenExists = false;

            var userId = jwt.Claims.FirstOrDefault(claim => claim.Type == "userId")?.Value;

            if (userId == null)
            {
                throw new InvalidOperationException("This refresh token is not valid");

            }

            var user = _userService.GetById(Convert.ToInt32(userId));

            if (!IsTokenExists(user.Tokens, refreshToken))
            {
                throw new InvalidOperationException("This refresh token is not exists");
            }

            if (!IsValidTokenLifetime(refreshToken))
            {
                RemoveRefreshTokenFromDb(user.UserId, refreshToken);

                throw new InvalidOperationException("The token's lifetime has expired");
            }

            RemoveRefreshTokenFromDb(user.UserId, refreshToken);

            return CreateJwt(user.Role.Name, user.Username, user.UserId, user.SecurityStamp);
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

        private SigningCredentials GetCredentials(string key)
        {
            var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            return signCredentials;
        }

        private void RemoveRefreshTokenFromDb(int userId, string refreshToken)
        {
            var tokenDto = new TokenDto
            {
                RefreshToken = refreshToken,
                UserId = userId,
                Id = 4//TODO:I thought the problem was this, but unlikely
            };

            _repository.Remove(Mapper.Map<Token>(tokenDto));
            //TODO: Crash after SaveChanges
            _repository.SaveChanges();
        }

        private bool IsTokenExists(ICollection<TokenDto> tokens, string refreshToken)
        {
            return tokens.Any(token => token.RefreshToken == refreshToken);
        }
    }
}