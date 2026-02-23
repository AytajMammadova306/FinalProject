using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.Persistance.Implementations.Services.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class AllFranchisesService:IAllFranchisesService
    {
        private readonly IFranchiseService _franchiseService;

        public AllFranchisesService(
            IFranchiseService franchiseService)
        {
            _franchiseService = franchiseService;
        }
        public async Task<AllFranchisesVM> GetAllFranchisesVMAsync(int page = 1, int take = 10)
        {
            ICollection<GetFranchiseItemVM> franchiseItemVMs = await _franchiseService.GetAllItemAsync();
            int totalCount = await _franchiseService.GetTotalCountAsync();
            AllFranchisesVM franchisesVM = new AllFranchisesVM
            {
                Franchises = franchiseItemVMs,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)totalCount / take),
                Take = take
            };
            return franchisesVM;
        }
    }
}
