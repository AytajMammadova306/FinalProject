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
        Task<ICollection<GetTvShowItemVM>> GetAllItemAsync();
        Task<GetTvShowVM> GetByIdAsync(long id);
    }
}
