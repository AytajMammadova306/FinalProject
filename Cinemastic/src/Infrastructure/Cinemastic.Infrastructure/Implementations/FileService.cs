using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Application.ViewModel.Files;
using Cinemastic.Infrastructure.OptionClasses;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Infrastructure.Implementations
{
    internal class FileService : IFileService
    {
        public readonly Cloudinary _cloudinary;
        public FileService(IOptions<CloudinarySettings> cloudConfig)
        {
            Account account = new Account
                (
                cloudConfig.Value.CloudName,
                cloudConfig.Value.ApiKey,
                cloudConfig.Value.ApiSecret
                );
            _cloudinary=new Cloudinary(account);
        }
        public async Task<FileVM> AddImageAsync(IFormFile file)
        {
            string fileName = Guid.NewGuid() + file.Name;
            ImageUploadResult result = new ImageUploadResult();

            using (var stream = file.OpenReadStream())
            {
                ImageUploadParams imageParams = new ImageUploadParams
                {
                    File = new FileDescription(fileName, stream)

                };
                result=await _cloudinary.UploadAsync(imageParams);
            }
            return new FileVM
            {
                FileName = fileName,
                Url = result.SecureUrl.ToString(),
                PublicId = result.PublicId,
            };
        }

        public async Task DeleteAsync(string publicId)
        {
            DeletionParams deletion = new DeletionParams(publicId);
            await _cloudinary.DestroyAsync(deletion);
        }
    }
}
