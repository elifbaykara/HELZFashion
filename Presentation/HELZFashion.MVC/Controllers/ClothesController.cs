using Microsoft.AspNetCore.Mvc;

namespace HELZFashion.MVC.Controllers
{
    public class ClothesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
