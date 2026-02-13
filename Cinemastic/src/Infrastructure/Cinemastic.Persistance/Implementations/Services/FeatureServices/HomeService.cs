using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.Slide;
using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class HomeService:IHomeService
    {
        private readonly IMovieService _movieService;
        private readonly ITvShowService _showService;
        private readonly ISlideService _slideService;

        public HomeService(
            IMovieService movieService,
            ITvShowService showService,
            ISlideService slideService
            )
        {
            _movieService=movieService;
            _showService = showService;
            _slideService = slideService;
        }

        public async Task<HomePageVM> GetHomePageVMAsync()
        {
            ICollection<GetMovieItemVM> movieItemVMs =await _movieService.GetAllAsync();
            ICollection<GetTvShowItemVM> showItemVMs = await _showService.GetAllAsync();
            ICollection<GetSlideVM> slideVMs = await _slideService.GetAllAsync();
            slideVMs = slideVMs.Where(sVM => sVM.ReleaseDate < DateTime.UtcNow).Take(2)//bu en son cixmis 2 dene
                .Concat(slideVMs
                    .OrderBy(sVM=>sVM.ReleaseDate)
                    .Where(sVM=>sVM.ReleaseDate>DateTime.UtcNow).Take(2))//en yaxinda olan cixma uze olanlar
                .ToList();

            HomePageVM homePageVM = new HomePageVM
            {
                LatestMovieItemVMs = movieItemVMs
                    .Where(cVM=>cVM.ReleaseDate<=DateTime.UtcNow)
                    .OrderByDescending(cVM=>cVM.ReleaseDate)
                    .Take(15)
                    .ToList(),
                CommingMovieItemVMs=movieItemVMs
                    .Where(cVM=>cVM.ReleaseDate>DateTime.UtcNow)
                    .OrderBy(cVM=>cVM.ReleaseDate)
                    .Take(15)
                    .ToList(),
                RecommendedTVShowItemVM=showItemVMs
                    .Take(15)
                    .ToList(),
                SlideVMs=slideVMs
            };
            return homePageVM;
        }
    }
}
