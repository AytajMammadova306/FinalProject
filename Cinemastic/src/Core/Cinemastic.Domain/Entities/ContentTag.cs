using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class ContentTag
    {
        public long ContentId { get; set; }
        public long TagId { get; set; }
        public Content Content { get; set; }
        public Tag Tag { get; set; }
    }
}
