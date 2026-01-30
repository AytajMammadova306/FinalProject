using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Content:BaseNameableEntity
    {
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public string Description {  get; set; }
        public ICollection<ContentGenre> ContentGenres { get; set; }
        public ICollection<ContentTag> ContentTags { get; set; }
        public ICollection<ContentCast> ContentCasts { get; set; }
        public ICollection<ContentCrew> ContentCrews { get; set; }
        public AgeRating AgeRating { get; set; }
        public ContentTypeCus ContentType { get; set; }
        public int? EpisodCount { get; set; }

    }
}
