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
    internal class ContentCrewConfiguration : IEntityTypeConfiguration<ContentCrew>
    {
        public void Configure(EntityTypeBuilder<ContentCrew> builder)
        {
            builder
                .HasKey(cc => new { cc.ContentId, cc.CrewId });
        }
    }
}
