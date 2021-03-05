using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YdyoOBS.Domain.Entities;

namespace YdyoOBS.Persistance.Configurations
{
    public class OgrenciTuruConfiguration : IEntityTypeConfiguration<OgrenciTuru>
    {
        public void Configure(EntityTypeBuilder<OgrenciTuru> builder)
        {
            builder.HasKey(e => e.Turu);

            builder.Property(e => e.Aciklama).HasMaxLength(50);

            builder.ToTable("OgrenciTuru");

        }
    }
}
