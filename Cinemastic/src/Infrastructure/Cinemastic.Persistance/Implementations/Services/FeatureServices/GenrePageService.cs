using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Featured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class GenrePageService:IGenrePageService
    {
        private readonly IGenreService _genreService;

        public GenrePageService(
            IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<GenrePageVM> GetGenrePageAsync()
        {
            ICollection<GenreCardVM> tvshowCards = await _genreService.GetTvShowGenreCardVMs();
            ICollection<GenreCardVM> movieCards = await _genreService.GetMovieGenreCardVMs();
            GenrePageVM genrePageVM = new GenrePageVM
            {
                MovieGenres = movieCards,
                TvShowGenres = tvshowCards,
            };
            return genrePageVM;
        }
    }
}
