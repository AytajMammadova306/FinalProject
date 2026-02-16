using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly IAllMoviesService _allMoviesService;
        private readonly IAllTvShowsService _allTvShowsService;
        private readonly IAllFranchisesService _allFranchisesService;

        public HomeController(
            IHomeService homeService,
            IAllMoviesService allMoviesService,
            IAllTvShowsService allTvShowsService,
            IAllFranchisesService allFranchisesService)
        {
            _homeService=homeService;
            _allMoviesService = allMoviesService;
            _allTvShowsService = allTvShowsService;
            _allFranchisesService = allFranchisesService;
        }
        public async Task<IActionResult> Index()
        {
            HomePageVM HomeVM =await _homeService.GetHomePageVMAsync();
            return View(HomeVM);
        }
        public async Task<IActionResult> AllMovies()
        {
            AllMoviesVM allMoviesVM = await _allMoviesService.GetAllMoviesVMAsync();
            return View(allMoviesVM);
        }
        public async Task<IActionResult> AllTvShows()
        {
            AllTvShowsVM allTvShowsVM = await _allTvShowsService.GetAllTvShowsAsync();
            return View(allTvShowsVM);
        }
        public async Task<IActionResult> AllFranchises()
        {
            AllFranchisesVM allFranchises = await _allFranchisesService.GetAllFranchisesVMAsync();
            return View(allFranchises);
        }
    }
}
