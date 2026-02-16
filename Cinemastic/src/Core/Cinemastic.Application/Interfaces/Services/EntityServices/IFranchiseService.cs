using Cinemastic.Application.ViewModel.Franchise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IFranchiseService
    {
        Task<ICollection<GetFranchiseItemVM>> GetAllItemAsync();
    }
}
