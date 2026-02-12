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
                .HasQueryFilter(mt=>!mt.Movie.IsDeleted);
            builder.Entity<MovieGenre>()
                .HasQueryFilter(mg=>!mg.Movie.IsDeleted);
            builder.Entity<MovieCast>()
                .HasQueryFilter(mc=>!mc.Movie.IsDeleted);
            builder.Entity<MovieCrew>()
                .HasQueryFilter(mc=>!mc.Movie.IsDeleted);

            builder.Entity<TvShowTag>()
                .HasQueryFilter(tst=>!tst.TvShow.IsDeleted);
            builder.Entity<TvShowGenre>()
                .HasQueryFilter(tsg=>!tsg.TvShow.IsDeleted);
            builder.Entity<TvShowCrew>()
                .HasQueryFilter(tsc=>!tsc.TvShow.IsDeleted);
            builder.Entity<TvShowCast>()
                .HasQueryFilter(tsc=>!tsc.TvShow.IsDeleted);
        }
        private static void ApplyQueryFilter<T>(this ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
