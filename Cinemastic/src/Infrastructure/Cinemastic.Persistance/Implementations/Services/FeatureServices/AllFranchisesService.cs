using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Application.ViewModel.Home;
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
        public async Task<AllFranchisesVM> GetAllFranchisesVMAsync()
        {
            ICollection<GetFranchiseItemVM> franchiseItemVMs = await _franchiseService.GetAllItemAsync();
            AllFranchisesVM franchisesVM = new AllFranchisesVM
            {
                Franchises = franchiseItemVMs
            };
            return franchisesVM;
        }
    }
}
