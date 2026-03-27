using Cinemastic.Application.ViewModel.Crew;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface ICrewService
    {
        Task<ICollection<GetCrewVM>> GetMovieCrewVMById(long id);
        Task<ICollection<GetCrewVM>> GetTvShowCrewVMById(long id);
        Task<ICollection<Crew>> GetAllCrewsAsync();
    }
}
