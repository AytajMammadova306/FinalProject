using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Application.ViewModel.Home;
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

        public TvShowDetailService(
            IActorService actorService,
            ICrewService crewService)
        {
            _crewService = crewService;
            _actorService = actorService;
        }

        public async Task<TvShowDetailPageVM> GetTvShowDetailVMAsync(long id)
        {
            ICollection<GetActorVM> actorVMs = await _actorService.GetMovieActorVMById(id);
            ICollection<GetCrewVM> crewVMs = await _crewService.GetMovieCrewVMById(id);

            TvShowDetailPageVM detailVM = new TvShowDetailPageVM
            {
                Starring = actorVMs,
                Crews = crewVMs,
            };
            return detailVM;
        }

    }
}
