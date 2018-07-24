using HiQo.StaffManagement.BL.Domain.Services;
using System.Web.Mvc;

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
            var listOfPositionLevelServices = _positionLevelService.GetAll(); 

            return View(listOfPositionLevelServices);
        }
    }
}