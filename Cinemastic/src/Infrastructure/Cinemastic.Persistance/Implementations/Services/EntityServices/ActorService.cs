using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class ActorService: IActorService
    {
        private readonly IActorRepository _repository;

        public ActorService(
            IActorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ICollection<GetActorVM>> GetMovieActorVMById(long id)
        {
            ICollection<GetActorVM> actorVMs = await _repository.GetAll(
                includes:"MovieCasts.Movie")
                .Where(a=>a.MovieCasts.Any(mc => mc.MovieId == id))
                .Select(a=>new GetActorVM
                {
                    ActorNameAndSurname=a.Name+" "+a.Surname,
                    ImageUrl=a.ImageUrl,
                    Role=a.MovieCasts
                        .Where(mc => mc.MovieId == id).FirstOrDefault().Role.ToString()
                }).ToListAsync();
            return actorVMs;
        }
        public async Task<ICollection<GetActorVM>> GetTvShowActorVMById(long id)
        {
            ICollection<GetActorVM> actorVMs = await _repository.GetAll(
                includes:"MovieCasts.Movie")
                .Where(a=>a.TvShowCasts.Any(mc => mc.TvShowId == id))
                .Select(a=>new GetActorVM
                {
                    ActorNameAndSurname=a.Name+" "+a.Surname,
                    ImageUrl=a.ImageUrl,
                    Role=a.TvShowCasts
                        .Where(mc => mc.TvShowId == id).FirstOrDefault().Role.ToString()
                }).ToListAsync();
            return actorVMs;
        }
        public async Task<ICollection<Actor>> GetAllActorsAsync()
        {
            ICollection<Actor> actors = await _repository.GetAll().ToListAsync();
            return actors;
        }

    }
}
