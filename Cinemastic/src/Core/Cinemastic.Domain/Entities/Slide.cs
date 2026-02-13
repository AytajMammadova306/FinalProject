using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Slide:BaseAccountableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long? MovieId {  get; set; }
        public long? TvShowId { get; set; }
        public Movie? Movie { get; set; }
        public TvShow? TvShow { get; set; }

        public int SeasonOrDuration { get; set; }
        public AgeRating? AgeRating { get; set; }
        public TvShowAgeRating? TvShowAgeRating { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
    }
}
