using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
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

        public HomeService(IMovieService movieService)
        {
            _movieService=movieService; 
        }

        public async Task<HomePageVM> GetHomePageVMAsync()
        {
            ICollection<GetMovieItemVM> movieItemVMs =await _movieService.GetAllAsync();

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
                    .ToList()
            };
            return homePageVM;
        }
    }
}
