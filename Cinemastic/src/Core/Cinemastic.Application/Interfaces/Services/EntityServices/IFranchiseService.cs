using Cinemastic.Application.ViewModel.Franchise;
using Cinemastic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface IFranchiseService
    {
        Task<ICollection<GetFranchiseItemVM>> GetAllItemAsync(int page = 0, int take = 0);
        Task<GetFranchiseVM> GetByIdAsync(long id);
        Task<int> GetTotalCountAsync();
        Task<ICollection<Franchise>> GetAllFranchiseAsync();
    }
}
