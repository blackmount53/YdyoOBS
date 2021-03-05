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
    public class SinifTurConfiguration : IEntityTypeConfiguration<SinifTur>
    {
        public void Configure(EntityTypeBuilder<SinifTur> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SinifTurID");

            builder.Property(e => e.Adi)
                   .HasColumnName("Aciklama")
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

        }
    }
}
