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
    internal class FranchiseConfiguration : IEntityTypeConfiguration<Franchise>
    {
        public void Configure(EntityTypeBuilder<Franchise> builder)
        {
            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(f => f.Description)
                .IsRequired();
        }
    }
}
