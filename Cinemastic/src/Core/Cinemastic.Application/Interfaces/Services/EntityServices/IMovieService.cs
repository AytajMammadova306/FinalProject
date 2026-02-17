using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IMovieService
    {
        Task<ICollection<GetMovieItemVM>> GetAllItemAsync();
        Task<GetMovieVM> GetByIdAsync(long id);
    }
}
