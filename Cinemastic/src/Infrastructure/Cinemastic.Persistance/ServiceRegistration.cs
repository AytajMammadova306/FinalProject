using Cinemastic.Application.Interfaces.Repositories;
using Cinemastic.Application.Interfaces.Services.EntityServices;
using Cinemastic.Application.Interfaces.Services.Feature_Services;
using Cinemastic.Persistance.Context;
using Cinemastic.Persistance.Implementations.Repositories;
using Cinemastic.Persistance.Implementations.Services.EntityServices;
using Cinemastic.Persistance.Implementations.Services.FeatureServices;
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
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICrewRepository, CrewRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IFranchiseRepository, FranchiseRepository>();
            services.AddScoped<ITvShowRepository, TvShowRepository>();
            services.AddScoped<ISeasonRepository, SeasonRepository>();
            services.AddScoped<IEpisodeRepository, EpisodeRepository>();
            services.AddScoped<ISlideRepository, SlideRepository>();

            


            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<ITvShowService, TvShowService>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<IFranchiseService, FranchiseService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<ICrewService, CrewService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IAllMoviesService, AllMoviesService>();
            services.AddScoped<IAllTvShowsService, AllTvShowsService>();
            services.AddScoped<IAllFranchisesService, AllFranchisesService>();
            services.AddScoped<IMovieDetailService, MovieDetailService>();
            services.AddScoped<ITvShowDetailService, TvShowDetailService>();
            
            

            return services;

        }
    }
}
