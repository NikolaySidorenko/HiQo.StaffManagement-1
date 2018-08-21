using System.Web.Mvc;
using HiQo.StaffManagement.BL.Domain.Services;

namespace HiQo.StaffManagement.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            var listOfCategories = _categoryService.GetAll();
            return View(listOfCategories);
        }
    }
}