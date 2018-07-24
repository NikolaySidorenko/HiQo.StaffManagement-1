using System.Linq;
using HiQo.StaffManagement.BL.Domain.Services;
using System.Web.Mvc;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class PositionLevelController : Controller
    {
        private readonly IPositionLevelService _positionLevelService;

        public PositionLevelController(IPositionLevelService positionLevelService)
        {
            _positionLevelService = positionLevelService;
        }

        // GET: PositionLevel
        public ActionResult Index()
        {

           var q = _positionLevelService.GetAll();

            return View();
        }
    }
}