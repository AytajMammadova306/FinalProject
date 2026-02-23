using Cinemastic.Application.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IFranchiseDetailService
    {
        Task<FranchiseDetailPageVM> GetFranchiseDetailPageVM(long id);
    }
}
