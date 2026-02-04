using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;

namespace Cinemastic.MVC.ViewModel.Movie
{
    public class GetContentVM
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int? EpisodCount { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
