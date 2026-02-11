using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Franchise:BaseNameableEntity
    {
        public string Description { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Movie> Movies { get; set; }
        public ICollection<TvShow> TvShows { get; set; }

    }
}
