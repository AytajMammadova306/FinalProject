using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;

namespace Cinemastic.MVC.ViewModel.Movie
{
    public class GetContentItemVM
    {
        public string Name { get; set; }
        public ICollection<string> Genre { get; set; }
        public int? EpisodCount { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
