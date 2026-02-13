using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShow:BaseNameableEntity
    {
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public int EpisodeCount { get; set; }
        public long? FranchiseId {  get; set; }
        public Franchise? Franchise { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public ICollection<TvShowCast> TvShowCasts { get; set;}
        public ICollection<TvShowCrew> TvShowCrews { get; set; }
        public ICollection<TvShowGenre> TvShowGenres { get; set; }
        public ICollection<TvShowTag> TvShowTags { get; set; }
        public TvShowAgeRating AgeRating { get; set; }
        public string ImageUrl {  get; set; }
        public Slide? Slide { get; set; }


    }
}
