using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class ContentCast
    {
        public int ContentId { get; set; }
        public int ActorId { get; set; }
        public Content Content { get; set; }
        public Actor Actor { get; set; }
        public RoleType Role { get; set; }
    }
}
