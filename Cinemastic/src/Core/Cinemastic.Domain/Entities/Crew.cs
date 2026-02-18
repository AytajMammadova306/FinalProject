using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Crew:BaseNameableEntity
    {
        public ICollection<MovieCrew> MovieCrews { get; set; }
        public ICollection<TvShowCrew> TvShowCrews { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
    }
}
