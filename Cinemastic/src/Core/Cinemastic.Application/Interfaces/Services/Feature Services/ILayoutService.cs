using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface ILayoutService
    {
        Task<Dictionary<string, string>> GetSettingAsync();
    }
}
