using Cinemastic.Application.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IAllTvShowsService
    {
        Task<AllTvShowsVM> GetAllTvShowsAsync(int page = 1, int take = 10);
    }
}
