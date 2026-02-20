using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.MVC.ViewModel.Movie;
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
        private readonly IActorService _actorService;
        private readonly ICrewService _crewService;

        public MovieDetailService(
            IMovieService movieService,
            IActorService actorService,
            ICrewService crewService)
        {
            _movieService = movieService;
            _actorService = actorService;
            _crewService = crewService;
        }
        public async Task<MovieDetailPageVM> GetMovieDetailVMAsync(long id)
        {
            GetMovieVM movieVM = await _movieService.GetByIdAsync(id);
            ICollection<GetMovieItemVM> movieItemVMs = await _movieService.GetAllItemAsync();
            ICollection<GetActorVM> actorVMs = await _actorService.GetMovieActorVMById(id);
            ICollection<GetCrewVM> crewVMs = await _crewService.GetMovieCrewVMById(id);
            MovieDetailPageVM detailPageVM = new MovieDetailPageVM
            {
                MovieVM = movieVM,
                Starring=actorVMs,
                Crews=crewVMs,
                ComingMovieItemVMs = movieItemVMs
                .Where(cVM => cVM.ReleaseDate > DateTime.UtcNow &&cVM.Id!=id)
                .OrderBy(cVM => cVM.ReleaseDate)
                .Take(15)
                .ToList(),
            };
            return detailPageVM;
        } 
    }
}
