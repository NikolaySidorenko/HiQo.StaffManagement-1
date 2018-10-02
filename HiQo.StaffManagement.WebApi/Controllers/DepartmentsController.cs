using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FluentValidation;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.ServiceResolver;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentsController : BaseAuthController
    {

        public DepartmentsController(IServiceFactory serviceFactory, IValidatorFactory validatorFactory)
            : base(serviceFactory, validatorFactory)
        {

        }


        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetAll()
        {
            var departments = ServiceFactory.Create<IDepartmentService>().GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, departments);
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(int id)
        {
            var department = ServiceFactory.Create<IDepartmentService>().GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Create(DepartmentDto department)
        {
            if (department != null)
            {
                ServiceFactory.Create<IDepartmentService>().Add(department);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest,department);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Update(DepartmentDto department)
        {
            if (department != null)
            {
                ServiceFactory.Create<IDepartmentService>().Update(department);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest, department);
        }

        [HttpDelete]
        [Route("")]
        public HttpResponseMessage Delete(int id)
        {
            ServiceFactory.Create<IDepartmentService>().Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
