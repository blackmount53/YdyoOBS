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
    public class BolumConfiguration : IEntityTypeConfiguration<Bolum>
    {
        public void Configure(EntityTypeBuilder<Bolum> builder)
        {
            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.Id).HasColumnName("BolumID");

            builder.Property(e => e.Adi)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.BolumNo)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnName("Department")
                .HasMaxLength(75)
                .IsUnicode(false);

            builder.Property(e => e.DurumId).HasColumnName("DurumID");

            builder.Property(e => e.FakulteNo)
                .IsRequired()
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.HasOne(b => b.Fakulte)
                .WithMany(f => f.Bolumler)
                .HasForeignKey(b => b.FakulteNo)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(b => b.BolumDurum)
              .WithMany(f => f.Bolumler)
              .HasForeignKey(b => b.DurumId)
              .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
