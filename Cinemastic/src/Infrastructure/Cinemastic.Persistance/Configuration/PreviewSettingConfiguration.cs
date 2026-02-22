using Cinemastic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cinemastic.Persistance.Configuration
{
    internal class PreviewSettingConfiguration : IEntityTypeConfiguration<PreviewSetting>
    {
        public void Configure(EntityTypeBuilder<PreviewSetting> builder)
        {
            builder.HasKey(s => s.Key);
        }
    }
}
