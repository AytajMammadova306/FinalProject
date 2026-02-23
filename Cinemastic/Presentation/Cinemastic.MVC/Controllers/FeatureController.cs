using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Featured;
using Microsoft.AspNetCore.Mvc;

namespace Cinemastic.MVC.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IGenrePageService _genrePageService;
        private readonly ITagPageService _tagPageService;

        public FeatureController(
            IGenrePageService genrePageService,
            ITagPageService tagPageService)
        {
            _genrePageService = genrePageService;
            _tagPageService = tagPageService;
        }
        public async Task<IActionResult> Genre()
        {
            GenrePageVM genrePageVM=await _genrePageService.GetGenrePageAsync();
            return View(genrePageVM);
        }
        public async Task<IActionResult> Tag()
        {
            TagPageVM pageVM=await _tagPageService.GetTagPageAsync();
            return View(pageVM);
        }
    }
}
