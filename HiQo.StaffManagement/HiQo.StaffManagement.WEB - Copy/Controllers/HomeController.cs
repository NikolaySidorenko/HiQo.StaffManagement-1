using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Models;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPositionLevelService _positionLevelService;

        //public HomeController(IPositionLevelService positionLevelService)
        //{
        //    _positionLevelService = positionLevelService;
        //}

        public ActionResult Index()
        {
            //var positionLevelDto =  _positionLevelService.GetAll().First();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}