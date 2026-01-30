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
    internal class ContentCastConfiguration : IEntityTypeConfiguration<ContentCast>
    {
        public void Configure(EntityTypeBuilder<ContentCast> builder)
        {
            builder
                .HasKey(cc => new { cc.ContentId, cc.ActorId });
        }
    }
}
