using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
