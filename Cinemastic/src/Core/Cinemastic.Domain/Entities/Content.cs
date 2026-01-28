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
        public List<ContentGenre> ContentGenres { get; set; }
        public List<ContentTag> ContentTags { get; set; }
        public List<ContentCast> ContentCasts { get; set; }
        public List<ContentCrew> ContentCrews { get; set; }
        public AgeRating AgeRating { get; set; }
        public ContentType ContentType { get; set; }
        public int? EpisodCount { get; set; }

    }
}
