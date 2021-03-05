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
    public class DersSaatiConfiguration : IEntityTypeConfiguration<DersSaati>
    {
        public void Configure(EntityTypeBuilder<DersSaati> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("SaatID");         

            builder.Property(e => e.Saat)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.Aciklama)
             .HasMaxLength(50)
             .IsUnicode(false);

            builder.ToTable("DersSaatleri");
        }
    }
}
