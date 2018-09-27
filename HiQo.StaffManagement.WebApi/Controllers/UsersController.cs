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
using HiQo.StaffManagement.Core.Filters;
using HiQo.StaffManagement.Core.ViewModels;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : BaseAuthController
    {
        public UsersController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory) : base(serviceFactory, validatorFactory)
        {
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var service = ServiceFactory.Create<IUserService>();
                var users = Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(service.GetAll());
                return Request.CreateResponse(HttpStatusCode.OK, users);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var service = ServiceFactory.Create<IUserService>();
                var user = Mapper.Map<UserViewModel>(service.GetById(id));
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody]UpdateUserViewModel user)
        {
            try
            {
                var validator = ValidatorFactory.GetValidator<UpdateUserViewModel>();
                var result = validator.Validate(user);
                if (!result.IsValid)
                {
                    SetErrors(result);
                    return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
                }

                var service = ServiceFactory.Create<IUserService>();
                service.Add(Mapper.Map<UserDto>(user));

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] UpdateUserViewModel user)
        {
            //TODO:validator
            try
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
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, id);
                }

                var service = ServiceFactory.Create<IUserService>();

                if (!service.IsExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, id);
                }

                service.Remove(id);

                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}