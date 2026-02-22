using Cinemastic.Application.Interfaces.Services.EntityServices;
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
        private readonly ITvShowDetailService _tvShowDetailService;
        private readonly IPlanPageService _planPageService;

        public HomeController(
            IHomeService homeService,
            IAllMoviesService allMoviesService,
            IAllTvShowsService allTvShowsService,
            IAllFranchisesService allFranchisesService,
            IMovieDetailService movieDetailService,
            ITvShowDetailService tvShowDetailService,
            IPlanPageService planPageService)
        {
            _homeService=homeService;
            _allMoviesService = allMoviesService;
            _allTvShowsService = allTvShowsService;
            _allFranchisesService = allFranchisesService;
            _movieDetailService = movieDetailService;
            _tvShowDetailService = tvShowDetailService;
            _planPageService = planPageService;
        }
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            HomePageVM HomeVM = await _homeService.GetHomePageVMAsync();
            return View(HomeVM);
        }
        public async Task<IActionResult> AllMovies()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllMoviesVM allMoviesVM = await _allMoviesService.GetAllMoviesVMAsync();
            return View(allMoviesVM);
        }
        public async Task<IActionResult> AllTvShows()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllTvShowsVM allTvShowsVM = await _allTvShowsService.GetAllTvShowsAsync();
            return View(allTvShowsVM);
        }
        public async Task<IActionResult> AllFranchises()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllFranchisesVM allFranchises = await _allFranchisesService.GetAllFranchisesVMAsync();
            return View(allFranchises);
        }
        public async Task<IActionResult> MovieDetail(long? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            MovieDetailPageVM detailPageVM=await _movieDetailService.GetMovieDetailVMAsync(id.Value);
            if (detailPageVM is null)
            {
                return NotFound();
            }
            return View(detailPageVM);
        }
        public async Task<IActionResult> TvShowDetail(long? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            TvShowDetailPageVM detailPageVM = await _tvShowDetailService.GetTvShowDetailVMAsync(id.Value);
            if (detailPageVM is null)
            {
                return NotFound();
            }
            return View(detailPageVM);
        }
        public async Task<IActionResult> Pricing()
        {
            return View(await _planPageService.GetPlanPageVM());
        }

    }
}
