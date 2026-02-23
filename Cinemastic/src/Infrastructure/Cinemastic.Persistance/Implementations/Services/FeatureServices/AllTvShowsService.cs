using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Application.ViewModel.TvShow;
using Cinemastic.Persistance.Implementations.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class AllTvShowsService:IAllTvShowsService
    {
        private readonly ITvShowService _tvShowService;

        public AllTvShowsService(ITvShowService tvShowService)
        {
            _tvShowService = tvShowService;
        }
        public async Task<AllTvShowsVM> GetAllTvShowsAsync(int page=1, int take=10)
        {
            ICollection<GetTvShowItemVM> tvShowItemVMs = await _tvShowService.GetAllItemAsync();
            int totalCount = await _tvShowService.GetTotalCountAsync();
            AllTvShowsVM allTvShowsVM = new AllTvShowsVM
            {
                TvShows = tvShowItemVMs,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalCount / take),
                Take = take
            };
            return allTvShowsVM;//bir yere yigmaq olar amma bele daha selqelidi mence
        }
    }
}
