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
    internal class TvShowTagConfiguration : IEntityTypeConfiguration<TvShowTag>
    {
        public void Configure(EntityTypeBuilder<TvShowTag> builder)
        {
            builder
                .HasKey(tst => new { tst.TvShowId, tst.TagId });
        }
    }
}
