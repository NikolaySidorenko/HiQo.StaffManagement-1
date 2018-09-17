using System.Collections.Generic;
using System.Web.Http;
using HiQo.StaffManagement.BL.Domain.Entities;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WebApi.Controllers
{
    public class DepartmentsController : ApiController
    {
        private readonly IDepartmentService _service;

        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet]
        public DepartmentDto GetSingle(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public IHttpActionResult Create(DepartmentDto department)
        {
            if (department != null)
            {
                _service.Add(department);
                return Ok(department);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public IHttpActionResult Update(DepartmentDto department)
        {
            if (department != null)
            {
                _service.Add(department);
                return Ok(department);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _service.Remove(id);
            return Ok(id);
        }

    }
}
