using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Slide:BaseAccountableEntity
    {
        public long? MovieId {  get; set; }
        public long? TvShowId { get; set; }
        public Movie? Movie { get; set; }
        public TvShow? TvShow { get; set; }
    }
}
