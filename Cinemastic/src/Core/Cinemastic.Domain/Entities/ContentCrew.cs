using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class ContentCrew
    {
        public long CrewId { get; set; }
        public long ContentId { get; set; }
        public Content Content { get; set; }
        public Crew Crew { get; set; }
        public CrewType CrewType { get; set; }
    }
}
