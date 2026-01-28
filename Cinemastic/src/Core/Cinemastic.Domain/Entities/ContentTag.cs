using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class ContentTag
    {
        public int ContentId { get; set; }
        public int TagId { get; set; }
        public Content Content { get; set; }
        public Tag Tag { get; set; }
    }
}
