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
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder
                .Property(p => p.Price)
                .HasColumnType("decimal(8,2)");
            builder.Property(p => p.AdFree).IsRequired();
            builder.Property(p => p.TvorLaptop).IsRequired();
            builder.Property(p => p.MaxQuality).IsRequired();
        }
    }
}
