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
    public class DerslikConfiguration : IEntityTypeConfiguration<Derslik>
    {
        public void Configure(EntityTypeBuilder<Derslik> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("DerslikID");

            builder.Property(e => e.Aciklama)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Adi)
                .HasColumnName("Derslik")
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.SinifTurId).HasColumnName("SinifTurID");

            builder.HasOne(d => d.SinifTur)
                .WithMany(st => st.Derslikler)
                .HasForeignKey(d => d.SinifTurId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
