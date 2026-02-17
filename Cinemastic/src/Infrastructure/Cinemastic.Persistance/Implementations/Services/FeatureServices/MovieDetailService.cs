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
    internal class MovieDetailService:IMovieDetailService
    {
        private readonly IMovieService _movieService;

        public MovieDetailService(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<MovieDetailPageVM> GetMovieDetailVMAsync(long id)
        {
            GetMovieVM movieVM = await _movieService.GetByIdAsync(id);
            MovieDetailPageVM detailPageVM = new MovieDetailPageVM
            {
                MovieVM = movieVM,
            };
            return detailPageVM;
        } 
    }
}
