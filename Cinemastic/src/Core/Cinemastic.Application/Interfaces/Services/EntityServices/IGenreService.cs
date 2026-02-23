using Cinemastic.Application.ViewModel.Featured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IGenreService
    {
        Task<ICollection<GenreCardVM>> GetMovieGenreCardVMs();
        Task<ICollection<GenreCardVM>> GetTvShowGenreCardVMs();
    }
}
