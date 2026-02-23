using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.Movie;
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
        public async Task<AllMoviesVM> GetAllMoviesVMAsync(int page = 0, int take = 0)
        {
            int totalCount = await _movieService.GetTotalCountAsync();
            ICollection<GetMovieItemVM> movieItemVMs = await _movieService.GetAllItemAsync(page, take);
            AllMoviesVM movieVMs = new AllMoviesVM
            {
                Movies = movieItemVMs,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalCount / take),
                Take = take
            };
            return movieVMs;
        }
    }
}
