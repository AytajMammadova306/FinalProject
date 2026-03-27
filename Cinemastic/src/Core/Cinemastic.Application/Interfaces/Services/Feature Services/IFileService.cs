using Cinemastic.Application.ViewModel.Files;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Application.Interfaces.Services.Feature_Services
{
    public interface IFileService
    {
        public Task<FileVM> AddImageAsync(IFormFile file);
        Task<FileVM> AddVideoAsync(IFormFile file);
        public Task DeleteAsync(string publicId);
    }
}
