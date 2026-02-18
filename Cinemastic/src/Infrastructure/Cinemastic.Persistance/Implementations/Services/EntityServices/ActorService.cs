using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.EntityServices
{
    internal class ActorService:IActorService
    {
        private readonly IActorRepository _repository;

        public ActorService(
            IActorRepository repository)
        {
            _repository = repository;
        }
    }
}
