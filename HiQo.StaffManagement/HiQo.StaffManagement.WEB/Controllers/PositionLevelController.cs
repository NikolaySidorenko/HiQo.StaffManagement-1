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

        //public PositionLevelController(PositionLevelService positionLevelService)
        //{
        //    _positionLevelService = positionLevelService;
        //}

        // GET: PositionLevel
        public ActionResult Index()
        {
            using (StaffManagementContext context = new StaffManagementContext())
            {
                IPositionLevelRepository positionLevelRepository = new PositionLevelRepository(context);
                IRepository baseRepository = new BaseRepository(context);
                PositionLevelService service = new PositionLevelService(positionLevelRepository,baseRepository);
                var obj = service.GetAll();
                return View(obj);
            }
        }
    }
}