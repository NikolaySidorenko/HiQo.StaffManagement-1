using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.DAL.Domain.Entities;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace HiQo.StaffManagement.Core.Providers
{
    public class TokenProvider : ITokenProvider
    {
       
        private readonly IServiceFactory  _factory;
        private readonly IRepository _repository;

        public TokenProvider(IServiceFactory factory,IRepository repository)
        {
            _factory = factory;
            _repository = repository;
        }


        public Jwt CreateJwt(string email)
        {
            var expireAccessTokenTime =
                DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesAccessToken"]));

            var expireRefreshTokenTime =
                DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(ConfigurationManager.AppSettings["expiryMinutesRefreshToken"]));

            var userDto = _factory.Create<IUserService>().GetAll().First(u => u.Username == email);

            var jwt = new Jwt
            {
                AccessToken = CreateAccessToken(userDto.Role.Name, userDto.Username, userDto.UserId, expireAccessTokenTime, userDto.SecurityStamp),
                RefreshToken = CreateRefreshToken(userDto.UserId, expireRefreshTokenTime, userDto.SecurityStamp),
                ExpiresIn = ((DateTimeOffset) expireAccessTokenTime).ToUnixTimeSeconds()
            };

            PassTokenToDb(jwt.RefreshToken,userDto);

            return jwt;
        }

        

        public Jwt UpdateAccessAndRefreshToken(string refreshToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(refreshToken);

            var value = jwt.Claims.FirstOrDefault(claim => claim.Type == "userId")?.Value;

            int id;
            if (value == null||!int.TryParse(value,out id))
            {
                return null;
            }

            var user = _factory.Create<IUserService>().GetById(id);

            if (!user.Tokens.Any(t => t.RefreshToken.Equals(refreshToken)))
            {
                return null;
            }

            if (!IsValidTokenLifetime(refreshToken))
            {
                DeleteRefreshTokenFromDb(user.UserId, refreshToken);

                return null;
            }

            DeleteRefreshTokenFromDb(user.UserId, refreshToken);

            var jwtOut = CreateJwt(user.Username);

            PassTokenToDb(jwtOut.RefreshToken, user);

            return jwtOut;
        }

       
        public void Delete(int userId)
        {
            throw new NotImplementedException();
        }

        private bool IsValidTokenLifetime(string token)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.ReadJwtToken(token);

            var expires = jwt.Payload.Exp;

            var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(Convert.ToDouble(expires)).ToUniversalTime();

            return dateTime.CompareTo(DateTime.UtcNow) >= 0;
        }

        private void PassTokenToDb(string refreshToken, UserDto user)
        {
            var tokenDto = new TokenDto
            {
                UserId = user.UserId,
                RefreshToken = refreshToken
            };

            _repository.Add(Mapper.Map<Token>(tokenDto));
            _repository.SaveChanges();
        }

        private string CreateAccessToken(string role, string username, int id, DateTime expire, string secretKey)
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
                audience: "HiQo",
                issuer: "HiQo",
                signingCredentials: GetCredentials(secretKey)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string CreateRefreshToken(int id, DateTime expire, string key)
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

        private SigningCredentials GetCredentials(string key)
        {
            var signCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

            return signCredentials;
        }

        private void DeleteRefreshTokenFromDb(int userId, string refreshToken)
        {
            var tokenFromDb = _repository
                .GetAll<Token>().First(token => token.UserId == userId && token.RefreshToken == refreshToken);

            _repository.Delete(tokenFromDb);
            _repository.SaveChanges();
        }
    }
}