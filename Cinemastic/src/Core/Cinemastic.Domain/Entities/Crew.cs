using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Crew:BaseNameableEntity
    {
        public ICollection<ContentCrew> ContentCrews { get; set; }
    }
}
