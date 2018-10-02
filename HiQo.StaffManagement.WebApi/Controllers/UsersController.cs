using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseAuthController
    {
        public UsersController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory) : base(
            serviceFactory, validatorFactory)
        {
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var service = ServiceFactory.Create<IUserService>();
            var users = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(service.GetAll());
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }


        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            var service = ServiceFactory.Create<IUserService>();
            var user = Mapper.Map<UserViewModel>(service.GetById(id));
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);   
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody] UpdateUserViewModel user)
        {
           
            var validator = ValidatorFactory.GetValidator<UpdateUserViewModel>();
            var result = validator.Validate(user);
            if (!result.IsValid)
            {
                SetErrors(result);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var service = ServiceFactory.Create<IUserService>();
            service.Add(Mapper.Map<UserDto>(user));

            return Request.CreateResponse(HttpStatusCode.Created);
        
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage UpdateUser([FromBody] UpdateUserViewModel user)
        {
            var validator = ValidatorFactory.GetValidator<UpdateUserViewModel>();
            var result = validator.Validate(user);

            if (!result.IsValid)
            {
                SetErrors(result);
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            var service = ServiceFactory.Create<IUserService>();
            service.Update(Mapper.Map<UserDto>(user));
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            var service = ServiceFactory.Create<IUserService>();

            if (!service.IsExists(id))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, id);
            }

            service.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, id);
    }
    }
}