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
    public class DevamsizlikConfiguration : IEntityTypeConfiguration<Devamsizlik>
    {
        public void Configure(EntityTypeBuilder<Devamsizlik> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("DevamsizlikID");

            builder.Property(e => e.DonemId).HasColumnName("DonemID");

            builder.Property(e => e.OgrId).HasColumnName("OgrID");

            builder.Property(e => e.HocaId).HasColumnName("HocaID");

            builder.Property(e => e.KayitTarih)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.DegistirmeTarihi).HasColumnType("datetime");

            builder.HasOne(d => d.Ogrenci)
                .WithMany(o => o.Devamsizliklar)
                .HasForeignKey(d => d.OgrId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Hoca)
               .WithMany(o => o.Devamsizliklar)
               .HasForeignKey(d => d.HocaId)
               .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
