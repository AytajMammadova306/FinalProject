using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Domain.Entities;
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

        public CrewService(
            ICrewRepository repository)
        {
            _repository = repository;
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
        public async Task<ICollection<GetCrewVM>> GetTvShowCrewVMById(long id)
        {
            ICollection<GetCrewVM> crewVMs = await _repository.GetAll()
                .Where(c => c.TvShowCrews.Any(mc => mc.TvShowId == id))
                .Select(c => new GetCrewVM
                {
                    CrewNameAndSurname = c.Name + " " + c.Surname,
                    ImageUrl = c.ImageUrl,
                    Type=c.TvShowCrews.Where(mc=>mc.TvShowId==id).FirstOrDefault().CrewType.ToString()
                }).ToListAsync();
            return crewVMs;
        }
        public async Task<ICollection<Crew>> GetAllCrewsAsync()
        {
            ICollection<Crew> crews = await _repository.GetAll().ToListAsync();
            return crews;
        }
    }
}
