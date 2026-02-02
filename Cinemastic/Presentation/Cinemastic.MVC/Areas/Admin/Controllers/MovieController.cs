using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
