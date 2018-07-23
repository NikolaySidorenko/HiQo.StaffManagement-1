using System.Linq;
using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;
using HiQo.StaffManagement.BL.Services;
using HiQo.StaffManagement.DAL.Context;
using HiQo.StaffManagement.DAL.Domain.Repositories;
using HiQo.StaffManagement.DAL.Repositories;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class TestController : Controller
    {
        private readonly IPositionLevelService _positionLevelService;

        public TestController(IPositionLevelService positionLevelService)
        {
            _positionLevelService = positionLevelService;
        }

        // GET: Test
        public ActionResult Index()
        {
            //using (StaffManagementContext context = new StaffManagementContext())
            //{
            //    IRepository rep = new BaseRepository(context);
            //    IPositionLevelRepository repository = new PositionLevelRepository(context);
            //    IPositionLevelService service = new PositionLevelService(repository,rep);
            //    var obj = service.GetAll().First();
            //}     
            
            return View();
        }
    }
}