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
    public class KurConfiguration : IEntityTypeConfiguration<Kur>
    {
        public void Configure(EntityTypeBuilder<Kur> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("KurID");

            builder.Property(e => e.Adi).HasColumnName("KurAdi")
                .HasMaxLength(25)
                .IsRequired()
                .IsUnicode(false);


            builder.Property(e => e.Aciklama)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DonemId).HasColumnName("DonemID");

            builder.Property(e => e.DevamsizlikDgs).HasColumnName("DevamsizlikDGS");

            builder.Property(e => e.HdersSaati).HasColumnName("HDersSaati");


            builder.HasOne(k => k.Donem)
                .WithMany(d => d.Kurlar)
                .HasForeignKey(k => k.DonemId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
