using Microsoft.AspNetCore.Mvc;

namespace HELZFashion.MVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
