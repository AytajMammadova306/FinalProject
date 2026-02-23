using Cinemastic.Application.ViewModel.Movie;
using Cinemastic.Application.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IMovieService
    {
        Task<ICollection<GetMovieItemVM>> GetAllItemAsync(int page = 0, int take = 0, int key = 0);
        Task<GetMovieVM> GetByIdAsync(long id);
        Task<int> GetTotalCountAsync();
        Task<ICollection<GetMovieItemVM>> GetByFranchiseAsync(long id);
        Task<ICollection<GetMovieAdminVM>> GetAllMovieVMs(int page = 0, int take = 0);
    }
}
