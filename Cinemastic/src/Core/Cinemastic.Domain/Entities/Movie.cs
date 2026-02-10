using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Movie:BaseNameableEntity
    {
        public DateTime? ReleaseDate { get; set; }
        public int? DurationMinutes { get; set; }
        public string Description {  get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieTag> MovieTags { get; set; }
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<MovieCrew> MovieCrews { get; set; }
        public AgeRating AgeRating { get; set; }
        public string ImageUrl { get; set; }

    }
}
