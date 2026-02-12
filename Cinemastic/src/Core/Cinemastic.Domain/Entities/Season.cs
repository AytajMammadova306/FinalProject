using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Season:BaseNameableEntity
    {
        public long TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        public int SeasonNumber { get; set; }
        public DateTime Releasedate { get; set; }
        public ICollection<Episode> Episodes { get; set; }

    }
}
