using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class MovieCrew
    {
        public long CrewId { get; set; }
        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public Crew Crew { get; set; }
        public CrewType CrewType { get; set; }
    }
}
