using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        // GET: Position
        public ActionResult Index()
        {
            var listOfPositions = _positionService.GetAll();

            return View(listOfPositions);
        }
    }
}