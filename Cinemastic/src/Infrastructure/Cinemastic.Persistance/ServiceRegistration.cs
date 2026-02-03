using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Persistance.Context;
using Cinemastic.Persistance.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("default")));//cloude u qosmaqa calisiram 3 gundu

            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ITagRepository, TagRepository>();


            return services;

        }
    }
}
