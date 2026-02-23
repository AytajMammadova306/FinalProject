using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Featured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Implementations.Services.FeatureServices
{
    internal class TagPageService:ITagPageService
    {
        private readonly ITagService _tagService;

        public TagPageService(
            ITagService tagService)
        {
            _tagService = tagService;
        }
        public async Task<TagPageVM> GetTagPageAsync()
        {
            ICollection<TagCardVM> movies = await _tagService.GetMovieTagCardVMs();
            ICollection<TagCardVM> tvShows = await _tagService.GetTvShowTagCardVMs();
            TagPageVM pageVM = new TagPageVM
            {
                MovieTags = movies,
                TvShowTags = tvShows,
            };
            return pageVM;
        }
    }
}
