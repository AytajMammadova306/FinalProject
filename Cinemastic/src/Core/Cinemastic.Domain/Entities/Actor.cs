using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Actor:BaseNameableEntity
    {
        public ICollection<MovieCast> MovieCasts { get; set; }
        public ICollection<TvShowCast> TvShowCasts { get; set; }
        
    }
}
