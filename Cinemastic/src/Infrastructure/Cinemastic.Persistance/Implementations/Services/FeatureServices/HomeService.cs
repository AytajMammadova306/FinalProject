using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
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

        public HomeService(
            IMovieService movieService,
            ITvShowService showService)
        {
            _movieService=movieService;
            _showService = showService;
        }

        public async Task<HomePageVM> GetHomePageVMAsync()
        {
            ICollection<GetMovieItemVM> movieItemVMs =await _movieService.GetAllAsync();
            ICollection<GetTvShowItemVM> showItemVMs = await _showService.GetAllAsync();

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
                    .ToList()
            };
            return homePageVM;
        }
    }
}
