using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShowTag
    {
        public long TagId { get; set; }
        public long TvShowId { get; set; }
        public Tag Tag { get; set; }
        public TvShow TvShow { get; set; }
    }
}
