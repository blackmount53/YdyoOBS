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
    public class SinifConfiguration : IEntityTypeConfiguration<Sinif>
    {
        public void Configure(EntityTypeBuilder<Sinif> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SinifID");
            builder.Property(e => e.Adi).HasColumnName("Sinif")
               .HasMaxLength(50)
               .IsRequired()
               .IsUnicode(false);
            builder.Property(e => e.Aciklama).HasMaxLength(50).IsRequired(false).IsUnicode(false);
            builder.Property(e => e.DonemId).IsRequired(false).HasColumnName("DonemID");
            builder.Property(e => e.KurId).IsRequired(false).HasColumnName("KurID");            
            builder.Property(e => e.HocaId).IsRequired(false).HasColumnName("HocaID");
            builder.Property(e => e.Aktif).HasColumnName("Aktiv");
            builder.Property(e => e.TemsilciId).IsRequired(false).HasColumnName("TemsilciID");

            builder.HasOne(s => s.Temsilci)
                .WithMany(o => o.Temsilciler)
                .HasForeignKey(s => s.TemsilciId)
                .OnDelete(DeleteBehavior.ClientSetNull);
              

            builder.HasOne(s => s.Kur)
                .WithMany(k => k.Siniflar)
                .HasForeignKey(s => s.KurId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasOne(s => s.Donem)
                .WithMany(d=>d.Siniflar)
                .HasForeignKey(s => s.DonemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(s => s.Hoca)
                .WithMany(h => h.Siniflar)
                .HasForeignKey(s => s.HocaId)
                .OnDelete(DeleteBehavior.ClientSetNull);


        }
    }
}
