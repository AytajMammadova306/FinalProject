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
    internal class TvShowGenreConfiguration : IEntityTypeConfiguration<TvShowGenre>
    {
        public void Configure(EntityTypeBuilder<TvShowGenre> builder)
        {
            builder
                .HasKey(tsg => new { tsg.TvShowId, tsg.GenreId });
        }
    }
}
