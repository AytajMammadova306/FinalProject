using Cinemastic.Application.ViewModel.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.ViewModel.Home
{
    public class AllFranchisesVM
    {
        public ICollection<GetFranchiseItemVM> Franchises { get; set; }
    }
}
