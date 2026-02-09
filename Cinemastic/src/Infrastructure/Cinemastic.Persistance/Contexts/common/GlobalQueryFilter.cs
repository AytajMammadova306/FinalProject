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
            builder.Entity<ContentTag>()
                .HasQueryFilter(ct=>!ct.Content.IsDeleted);
            builder.Entity<ContentGenre>()
                .HasQueryFilter(cg=>!cg.Content.IsDeleted);
            builder.Entity<ContentCast>()
                .HasQueryFilter(cc=>!cc.Content.IsDeleted);
            builder.Entity<ContentCrew>()
                .HasQueryFilter(cc=>!cc.Content.IsDeleted);
        }
        private static void ApplyQueryFilter<T>(this ModelBuilder builder) where T : BaseEntity, new()
        {
            builder.Entity<T>().HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
