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
        private readonly IMovieDetailService _movieDetailService;

        public HomeController(
            IHomeService homeService,
            IAllMoviesService allMoviesService,
            IAllTvShowsService allTvShowsService,
            IAllFranchisesService allFranchisesService,
            IMovieDetailService movieDetailService)
        {
            _homeService=homeService;
            _allMoviesService = allMoviesService;
            _allTvShowsService = allTvShowsService;
            _allFranchisesService = allFranchisesService;
            _movieDetailService = movieDetailService;
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
        public async Task<IActionResult> MovieDetail(long? id)
        {
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            MovieDetailPageVM detailPageVM=await _movieDetailService.GetMovieDetailVMAsync(id.Value);
            return View(detailPageVM);
        }

    }
}
