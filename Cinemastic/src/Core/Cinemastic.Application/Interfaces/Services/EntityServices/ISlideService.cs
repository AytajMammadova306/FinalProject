using Cinemastic.Application.ViewModel.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.EntityServices
{
    public interface ISlideService
    {
        Task<ICollection<GetSlideVM>> GetAllItemAsync();
    }
}
