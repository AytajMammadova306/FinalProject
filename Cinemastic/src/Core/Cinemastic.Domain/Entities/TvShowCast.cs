using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShowCast
    {
        public long TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        public long ActorId { get; set; }
        public Actor Actor { get; set; }
        public RoleType Role { get; set; }
    }
}
