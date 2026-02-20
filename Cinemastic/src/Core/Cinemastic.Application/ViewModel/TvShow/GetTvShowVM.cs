using Cinemastic.Application.ViewModel.Episode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.TvShow
{
    public class GetTvShowVM
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public string AgeRating { get; set; }
        public string ImageUrl { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string VideoUrl { get; set; }
        public long? FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public ICollection<string> Genres { get; set; }
        public ICollection<string> Tags { get; set; }
        public ICollection<string> Casts { get; set; }
        public ICollection<string> Crews { get; set; }
        public ICollection<long> SeasonIds { get; set; }
        public ICollection<GetEpisodeItemVM> Episodes { get; set; }

    }
}
