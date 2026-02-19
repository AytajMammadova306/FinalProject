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
        public async Task<ICollection<GetActorVM>> GetActorVMById(long id)
        {
            ICollection<GetActorVM> actorVM = await _repository.GetAll(
                includes:"MovieCasts.Movie").Select(m=>new GetActorVM
                {
                    ActorNameAndSurname=m.Name+" "+m.Surname,
                    ImageUrl=m.ImageUrl,
                    Role=m.MovieCasts.Where(mc => mc.MovieId == id).FirstOrDefault().Role.ToString()
                }).ToListAsync();
            return actorVM;
        }
    }
}
