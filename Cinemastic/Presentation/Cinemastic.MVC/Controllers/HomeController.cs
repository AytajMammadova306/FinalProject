using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService=homeService;
        }
        public async Task<IActionResult> Index()
        {
            HomePageVM HomeVM =await _homeService.GetHomePageVMAsync();
            return View(HomeVM);
        }
    }
}
