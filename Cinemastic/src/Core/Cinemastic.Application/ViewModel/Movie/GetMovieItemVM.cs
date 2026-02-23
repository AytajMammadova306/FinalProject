using Cinemastic.Domain.Entities;
using Cinemastic.Domain.Enums;

namespace Cinemastic.Application.ViewModel.Movie
{
    public class GetMovieItemVM
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<string> Genres { get; set; }
        public int GenresCount { get; set; } = 0;
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
