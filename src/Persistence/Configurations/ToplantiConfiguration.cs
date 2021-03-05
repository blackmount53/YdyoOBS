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
    public class ToplantiConfiguration : IEntityTypeConfiguration<Toplanti>
    {
        public void Configure(EntityTypeBuilder<Toplanti> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("ToplantiID");

            builder.Property(e => e.HocaId).HasColumnName("HocaID");

            builder.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

            builder.Property(e => e.KayitTarihi)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.ToplantiAdi)               
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.ToplantiKonusu)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.ToplantiTarihi).HasColumnType("datetime");

            builder.Property(e => e.ToplantiYeri)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(t => t.Hoca)
                .WithMany(h => h.Toplantilar)
                .HasForeignKey(t => t.HocaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
