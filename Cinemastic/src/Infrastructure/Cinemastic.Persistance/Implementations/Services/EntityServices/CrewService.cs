using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Crew;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ICollection<GetCrewVM>> GetMovieCrewVMById(long id)
        {
            ICollection<GetCrewVM> crewVMs = await _repository.GetAll()
                .Where(c => c.MovieCrews.Any(mc => mc.MovieId == id))
                .Select(c => new GetCrewVM
                {
                    CrewNameAndSurname = c.Name + " " + c.Surname,
                    ImageUrl = c.ImageUrl,
                    Type=c.MovieCrews.Where(mc=>mc.MovieId==id).FirstOrDefault().CrewType.ToString()
                }).ToListAsync();
            return crewVMs;
        }
    }
}
