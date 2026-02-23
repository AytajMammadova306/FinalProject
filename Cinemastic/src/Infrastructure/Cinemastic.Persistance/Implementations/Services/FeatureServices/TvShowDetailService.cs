using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.Application.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class TvShowDetailService:ITvShowDetailService
    {
        private readonly ICrewService _crewService;
        private readonly IActorService _actorService;
        private readonly ITvShowService _tvShowDetailService;
        private readonly IMovieService _movieService;
        private readonly ITvShowService _tvShowService;

        public TvShowDetailService(
            IMovieService movieService,
            ITvShowService tvShowService,
            IActorService actorService,
            ICrewService crewService,
            ITvShowService tvShowDetailService)
        {
            _crewService = crewService;
            _actorService = actorService;
            _tvShowDetailService = tvShowDetailService;
            _movieService = movieService;
            _tvShowService = tvShowService;
        }

        public async Task<TvShowDetailPageVM> GetTvShowDetailVMAsync(long id)
        {
            ICollection<GetActorVM> actorVMs = await _actorService.GetTvShowActorVMById(id);
            ICollection<GetCrewVM> crewVMs = await _crewService.GetTvShowCrewVMById(id);
            GetTvShowVM tvShowVM = await _tvShowDetailService.GetByIdAsync(id);
            ICollection<GetMovieItemVM> movieItemVMs = await _movieService.GetAllItemAsync();
            ICollection<GetTvShowItemVM> tvShowItemVMs = await _tvShowService.GetAllItemAsync();
            


            TvShowDetailPageVM detailVM = new TvShowDetailPageVM
            {
                Starring = actorVMs,
                Crews = crewVMs,
                TvShowVM = tvShowVM,
                ComingMovieItemVMs = movieItemVMs
                    .Where(cVM => cVM.ReleaseDate > DateTime.UtcNow && cVM.Id != id)
                    .OrderBy(cVM => cVM.ReleaseDate)
                    .Take(15)
                    .ToList(),
                ComingTvShowItemVMs = tvShowItemVMs
                    .Where(cVM => cVM.ReleaseDate > DateTime.UtcNow && cVM.Id != id)
                    .OrderBy(cVM => cVM.ReleaseDate)
                    .Take(15)
                    .ToList(),
            };
            return detailVM;
        }

    }
}
