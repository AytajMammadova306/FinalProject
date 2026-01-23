using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Movie:BaseNameableEntity
    {
        public int DurationMinutes { get; set; }
        public string Description {  get; set; }
        public List<MovieGenre> MovieGenres { get; set; }
        public List<MovieTag> MovieTags { get; set; }
    }
}
