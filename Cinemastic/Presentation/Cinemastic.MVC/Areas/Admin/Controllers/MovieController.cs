using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Cinemastic.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class MovieController : Controller
    {
        private readonly IAdminMovieService _adminMovieService;

        public MovieController(
            IAdminMovieService adminMovieService)
        {
            _adminMovieService = adminMovieService;
        }
        public async Task<IActionResult> Index( int page = 1, int take = 10)
        {
            GetMovieAdminPageVM pageVM = await _adminMovieService.GetMovieVMsAdmin(page, take);

            return View(pageVM);
        }
        public async Task<IActionResult> Create()
        {
            CreateMovieVM movieVM =await _adminMovieService.CreateGetMovieAsync();
            return View(movieVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieVM movieVM)
        {
            if (!ModelState.IsValid) return View(movieVM);
            bool result = await _adminMovieService.CreatePostMovieAsync(movieVM, ModelState);

            return View();
        }
        //public async Task<IActionResult> Update()
        //{
        //    return View();
        //}
    }
}
