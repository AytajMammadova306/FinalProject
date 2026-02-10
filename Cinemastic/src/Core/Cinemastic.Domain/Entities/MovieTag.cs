using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class MovieTag
    {
        public long MovieId { get; set; }
        public long TagId { get; set; }
        public Movie Movie { get; set; }
        public Tag Tag { get; set; }
    }
}
