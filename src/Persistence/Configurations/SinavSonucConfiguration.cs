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
    public class SinavSonucConfiguration : IEntityTypeConfiguration<SinavSonuc>
    {
        public void Configure(EntityTypeBuilder<SinavSonuc> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("SinavID");

            builder.Property(e => e.OgrId).HasColumnName("OgrID");

            builder.Property(e => e.SinavTurId).HasColumnName("SinavTurID");

            builder.Property(e => e.HocaId).HasColumnName("HocaID");           

            builder.Property(e => e.KayitTarihi)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

            builder.Property(e => e.DonemId).HasColumnName("DonemID");

            builder.Property(e => e.Notu).HasColumnType("decimal(5, 2)");

            builder.HasOne(ss => ss.Hoca)
                .WithMany(h => h.SinavSonuclari)
                .HasForeignKey(ss => ss.HocaId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(ss => ss.Ogrenci)
                .WithMany(h => h.SinavSonuclari)
                .HasForeignKey(ss => ss.OgrId)
                .OnDelete(DeleteBehavior.ClientSetNull);



        }
    }
}
