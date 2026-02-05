using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Home;
using Cinemastic.MVC.ViewModel.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class HomeService:IHomeService
    {
        private readonly IContentService _contentService;

        public HomeService(IContentService contentService)
        {
            _contentService=contentService; 
        }

        public async Task<HomePageVM> GetHomePageVMAsync()
        {
            ICollection<GetContentItemVM> contentItemVMs =await _contentService.GetAllAsync();

            HomePageVM homePageVM = new HomePageVM
            {
                ContentItemVMs = contentItemVMs
            };
            return homePageVM;
        }
    }
}
