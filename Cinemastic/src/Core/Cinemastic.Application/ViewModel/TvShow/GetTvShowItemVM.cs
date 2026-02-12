using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.TvShow
{
    public class GetTvShowItemVM
    {
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<string> Genres { get; set; }
        public int GenresCount { get; set; } = 0;
        public int SeasonCount { get; set; } = 0;
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
