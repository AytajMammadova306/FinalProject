using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;

namespace Cinemastic.MVC.ViewModel.Movie
{
    public class GetContentVM
    {
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public string Description { get; set; }
        public ICollection<ContentGenre> ContentGenres { get; set; }
        public ICollection<ContentTag> ContentTags { get; set; }
        public ICollection<ContentCast> ContentCasts { get; set; }
        public ICollection<ContentCrew> ContentCrews { get; set; }
        public AgeRating AgeRating { get; set; }
        public ContentTypeCus ContentType { get; set; }
        public int? EpisodCount { get; set; }
        public string ImageUrl { get; set; }
    }
}
