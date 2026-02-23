using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Infrastructure.Implementations;
using Cinemastic.Infrastructure.OptionClasses;
using Cinemastic.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<IFileService, FileService>();
            return services;
        }
    }
}
