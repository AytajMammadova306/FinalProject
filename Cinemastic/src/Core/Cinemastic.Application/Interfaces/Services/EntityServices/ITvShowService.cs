using Cinemastic.Application.ViewModel.TvShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface ITvShowService
    {
        Task<ICollection<GetTvShowItemVM>> GetAllItemAsync(int page = 0, int take = 0);
        Task<GetTvShowVM> GetByIdAsync(long id);
        Task<int> GetTotalCountAsync();
        Task<ICollection<GetTvShowItemVM>> GetByFranchiseAsync(long id);
    }
}
