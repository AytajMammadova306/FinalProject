using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Plan
{
    public class PlanVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
        public bool AdFree { get; set; }
        public bool TvorLaptop { get; set; }
        public bool MaxQuality { get; set; }
        public int DurationValue { get; set; }
        public string Interval { get; set; }
    }
}
