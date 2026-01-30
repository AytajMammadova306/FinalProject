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
    internal class ContentGenreConfiguration : IEntityTypeConfiguration<ContentGenre>
    {
        public void Configure(EntityTypeBuilder<ContentGenre> builder)
        {
            builder
                .HasKey(cg => new { cg.ContentId, cg.GenreId });
        }
    }
}
