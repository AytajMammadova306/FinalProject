using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShowGenre
    {
        public long GenreId { get; set; }
        public long TvShowId { get; set; }
        public Genre Genre { get; set; }
        public TvShow TvShow { get; set; }
    }
}
