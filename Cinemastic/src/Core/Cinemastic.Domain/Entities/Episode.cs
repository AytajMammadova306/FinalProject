using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Episode:BaseNameableEntity
    {
        public int DurationInMinutes { get; set; }
        public int EpisodNumber { get; set; }
        public Season Season { get; set; }
        public int SeasonId { get; set; }
        public string Description { get; set; }
    }
}
