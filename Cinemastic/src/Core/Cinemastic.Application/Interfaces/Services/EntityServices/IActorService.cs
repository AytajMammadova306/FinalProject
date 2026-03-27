using Cinemastic.Application.ViewModel.Actor;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IActorService
    {
        Task<ICollection<GetActorVM>> GetMovieActorVMById(long id);
        Task<ICollection<GetActorVM>> GetTvShowActorVMById(long id);
        Task<ICollection<Actor>> GetAllActorsAsync();
    }
}
