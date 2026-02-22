using Cinemastic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Domain.Entities
{
    public class Plan:BaseNameableEntity
    {
        public decimal Price { get; set; }
        public int DurationValue { get; set; }
        public PlanInterval Interval { get; set; }
        public bool AdFree { get; set; }
        public bool TvorLaptop {  get; set; }
        public bool MaxQuality { get; set; }
    }
}
