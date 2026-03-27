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
        private readonly IFranchiseDetailService _franchiseDetailService;

        public HomeController(
            IHomeService homeService,
            IAllMoviesService allMoviesService,
            IAllTvShowsService allTvShowsService,
            IAllFranchisesService allFranchisesService,
            IMovieDetailService movieDetailService,
            ITvShowDetailService tvShowDetailService,
            IPlanPageService planPageService,
            IFranchiseDetailService franchiseDetailService)
        {
            _homeService=homeService;
            _allMoviesService = allMoviesService;
            _allTvShowsService = allTvShowsService;
            _allFranchisesService = allFranchisesService;
            _movieDetailService = movieDetailService;
            _tvShowDetailService = tvShowDetailService;
            _planPageService = planPageService;
            _franchiseDetailService = franchiseDetailService;
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
        public async Task<IActionResult> AllMovies(int page = 1, int take = 10, int key = 1)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllMoviesVM allMoviesVM = await _allMoviesService.GetAllMoviesVMAsync(page, take, key);
            
            return View(allMoviesVM);
        }
        public async Task<IActionResult> AllTvShows(int page = 1, int take = 10)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllTvShowsVM allTvShowsVM = await _allTvShowsService.GetAllTvShowsAsync(page,take);
            return View(allTvShowsVM);
        }
        public async Task<IActionResult> AllFranchises(int page = 1, int take = 10)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            AllFranchisesVM allFranchises = await _allFranchisesService.GetAllFranchisesVMAsync(page,take);
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
        public async Task<IActionResult> Player(string coverUrl, string videoUrl, string? returnUrl)
        {
            if(string.IsNullOrEmpty(videoUrl)) return BadRequest();
            PlayerVM player = new PlayerVM
            {
                CoverUrl = coverUrl,
                VideoUrl = videoUrl,
                ReturnUrl=returnUrl,
            };
            return View(player);
        }
        public async Task<IActionResult> FranchiseDetail(long? id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Preview");
            }
            if (id == null || id < 1)
            {
                return BadRequest();
            }
            FranchiseDetailPageVM detailPageVM = await _franchiseDetailService.GetFranchiseDetailPageVM(id.Value);
            if (detailPageVM is null) return NotFound();
            return View(detailPageVM);
        }
        public async Task<IActionResult> Pricing()
        {
            return View(await _planPageService.GetPlanPageVM());
        }

    }
}
