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
    internal class TvShowConfiguration : IEntityTypeConfiguration<TvShow>
    {
        public void Configure(EntityTypeBuilder<TvShow> builder)
        {
            builder.Property(ts => ts.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(ts => ts.Description)
                .IsRequired();
        }
    }
}
