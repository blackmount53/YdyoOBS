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
    public class TelafiConfiguration : IEntityTypeConfiguration<Telafi>
    {
        public void Configure(EntityTypeBuilder<Telafi> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("TelafiID");

            builder.Property(e => e.Aciklama).IsUnicode(false);

            builder.Property(e => e.DersId).HasColumnName("DersID");

            builder.Property(e => e.DerslikId).HasColumnName("DerslikID");

            builder.Property(e => e.DonemId).HasColumnName("DonemID");

            builder.Property(e => e.GirTarih)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.HocaId).HasColumnName("HocaID");

            builder.Property(e => e.Onay).HasDefaultValueSql("((0))");

            builder.Property(e => e.OnayId).HasColumnName("OnayID");

            builder.Property(e => e.OnayTarihi).HasColumnType("datetime");

            builder.Property(e => e.SinifId).HasColumnName("SinifID");

            builder.Property(e => e.Tarih)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TelafiTarihi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(e => e.Hoca)
                .WithMany(h => h.Telafiler)
                .HasForeignKey(e=>e.HocaId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasOne(e => e.Donem)
                .WithMany(h => h.Telafiler)
                .HasForeignKey(e => e.DonemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.ToTable("Telafi");

        }
    }
}
