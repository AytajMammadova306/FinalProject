using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    internal abstract class BaseEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
