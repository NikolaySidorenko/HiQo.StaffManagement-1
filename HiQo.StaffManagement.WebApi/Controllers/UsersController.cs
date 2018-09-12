using System.Collections.Generic;
using System.Linq;
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
        private readonly IUpsertService _upsertService;
        private readonly IUserService _userService;

        public UsersController(IUpsertService upsertService, IUserService userService)
        {
            _upsertService = upsertService;
            _userService = userService;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<UpdateUserViewModel> GetUsers()
        {
            return Mapper.Map<IEnumerable<UserDto>, IEnumerable<UpdateUserViewModel>>(_userService.GetAll());
        }
    }
}