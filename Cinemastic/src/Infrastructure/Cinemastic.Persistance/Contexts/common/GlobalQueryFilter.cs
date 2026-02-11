using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Context.common
{
    internal static class GlobalQueryFilter
    {
        public static void ApplyAllQueryFilters(this ModelBuilder builder)
        { 
            builder.ApplyQueryFilter<Actor>();
            builder.ApplyQueryFilter<Crew>();
            builder.ApplyQueryFilter<Genre>();
            builder.ApplyQueryFilter<Movie>();
            builder.ApplyQueryFilter<Tag>();
            builder.ApplyQueryFilter<Franchise>();
            builder.ApplyQueryFilter<TvShow>();
            builder.ApplyQueryFilter<Season>();
            builder.ApplyQueryFilter<Episode>();
            builder.Entity<MovieTag>()
                .HasQueryFilter(ct=>!ct.Movie.IsDeleted);
            builder.Entity<MovieGenre>()
                .HasQueryFilter(cg=>!cg.Movie.IsDeleted);
            builder.Entity<MovieCast>()
                .HasQueryFilter(cc=>!cc.Movie.IsDeleted);
            builder.Entity<MovieCrew>()
                .HasQueryFilter(cc=>!cc.Movie.IsDeleted);
        }
        private static void ApplyQueryFilter<T>(this ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
