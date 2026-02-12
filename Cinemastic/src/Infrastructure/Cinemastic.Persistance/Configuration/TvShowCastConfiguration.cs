using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemastic.Persistance.Configuration
{
    internal class TvShowCastConfiguration : IEntityTypeConfiguration<TvShowCast>
    {
        public void Configure(EntityTypeBuilder<TvShowCast> builder)
        {
            builder
                .HasKey(tsc => new { tsc.TvShowId, tsc.ActorId });
        }
    }
}
