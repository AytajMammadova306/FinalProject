using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Plan
{
    public class PlanPageVM
    {
        public ICollection<PlanVM> PlanVMs { get; set; }
        public string BackGround { get; set; }
    }
}
