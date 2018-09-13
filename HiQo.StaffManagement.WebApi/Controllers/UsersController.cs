using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            try
            {
               var users = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(_userService.GetAll());
               return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [Route("{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            try
            {
                var user = Mapper.Map<UserViewModel>(_userService.GetById(id));
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        //[Route("")]
        //[HttpPost]
        //public HttpResponseMessage AddUser(UpdateUserViewModel user)
        //{
        //    try
        //    {
        //        _userService.Add(Mapper.Map<UserDto>(user));
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
        //    }
        //}

        [Route("{id:int}")]
        [HttpPut]
        public HttpResponseMessage UpdateUser([FromBody] UpdateUserViewModel user)
        {
            //TODO:validator
            try
            {
                _userService.Update(Mapper.Map<UserDto>(user));
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        [Route("locations")]
        [HttpGet]
        public HttpResponseMessage LocationsOfUsers()
        {
            try
            {
                var locations = Mapper.Map<IEnumerable<UserDto>, IEnumerable<MapViewModel>>(_userService.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, locations);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
        


    }
}