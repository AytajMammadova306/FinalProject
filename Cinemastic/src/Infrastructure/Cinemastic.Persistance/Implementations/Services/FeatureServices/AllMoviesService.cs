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
    internal class AllMoviesService:IAllMoviesService
    {
        private readonly IMovieService _movieService;

        public AllMoviesService(
            IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<AllMoviesVM> GetAllMoviesVMAsync()
        {
            ICollection<GetMovieItemVM> movieItemVMs = await _movieService.GetAllItemAsync();
            AllMoviesVM movies = new AllMoviesVM
            {
                Movies = movieItemVMs
            };
            return movies;
        }
    }
}
