using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class TvShowCrew
    {
        public long TvShowId { get; set; }
        public TvShow TvShow { get; set; }
        public long CrewId { get; set; }
        public Crew Crew { get; set; }
        public CrewType CrewType { get; set; }
    }
}
