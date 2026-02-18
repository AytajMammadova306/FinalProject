using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Crew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class CrewService:ICrewService
    {
        private readonly ICrewRepository _repository;
        private readonly IMovieService _movieService;

        public CrewService(
            ICrewRepository repository,
            IMovieService movieService)
        {
            _repository = repository;
            _movieService = movieService;
        }
        public async Task<GetCrewVM> GetMovieCrewVMById()
        {
            
        }
    }
}
