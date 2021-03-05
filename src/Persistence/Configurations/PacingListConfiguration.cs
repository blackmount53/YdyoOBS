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
    public class PacingListConfiguration : IEntityTypeConfiguration<PacingList>
    {
        public void Configure(EntityTypeBuilder<PacingList> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PacingListID");

            builder.Property(e => e.DegTarihi).HasColumnType("datetime");

            builder.Property(e => e.DonemId).HasColumnName("DonemID");

            builder.Property(e => e.GrammarExplorer)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.HocaId).HasColumnName("HocaID");

            builder.Property(e => e.KayitTarihi)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.KulId).HasColumnName("KulID");

            builder.Property(e => e.LanguageLeader)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PracticalEnglish)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.SinifId).HasColumnName("SinifID");

            builder.Property(e => e.Speaking)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Sure)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Tarih).HasColumnType("datetime");

            builder.Property(e => e.TopGrammar)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Touchstone)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Video)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Vocab)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Writing)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(pl => pl.Hoca)
               .WithMany(h => h.PacingListler)
               .HasForeignKey(pl => pl.HocaId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(pl => pl.Donem)
              .WithMany(h => h.PacingListler)
              .HasForeignKey(pl => pl.DonemId)
              .OnDelete(DeleteBehavior.ClientSetNull);


            builder.ToTable("PacingList");

        }
    }
}
