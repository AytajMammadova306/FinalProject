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
    internal class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.Property(s => s.CoverUrl)
                .IsRequired();
            builder.Property(s=>s.TrailerUrl)
                .IsRequired();
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasOne(s => s.Movie)
                .WithOne(m => m.Slide)
                .HasForeignKey<Slide>(s => s.MovieId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(s => s.TvShow)
                .WithOne(t => t.Slide)
                .HasForeignKey<Slide>(s => s.TvShowId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);



        }
    }
}
