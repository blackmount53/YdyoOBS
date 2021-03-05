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
    public class SinavTurConfiguration : IEntityTypeConfiguration<SinavTur>
    {
        public void Configure(EntityTypeBuilder<SinavTur> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("SinavTurID");

            builder.Property(e => e.Adi)
             .HasColumnName("SinavTuru")
             .HasMaxLength(50)
             .IsRequired()
             .IsUnicode(false);

            builder.Property(e => e.Aktif)
                .HasColumnName("Acik")
                .HasDefaultValueSql("((0))");

            builder.Property(e => e.Aciklama)
                .HasMaxLength(50)
                .IsRequired(false)
                .IsUnicode(false);

            builder.Property(e => e.SinifId)
               .HasColumnName("SinifID")
               .IsRequired(false);

            builder.Property(e => e.DonemId)
                .HasColumnName("DonemID")
                .IsRequired(false);

            builder.Property(e => e.Katsayi).HasColumnType("decimal(5, 4)");

            builder.Property(e => e.Siralama)
                .IsRequired(false);

            builder.HasOne(st => st.Donem)
                .WithMany(d => d.SinavTurleri)
                .HasForeignKey(st => st.DonemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(st => st.Sinif)
                   .WithMany(d => d.SinavTurleri)
                   .HasForeignKey(st => st.SinifId)
                   .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
