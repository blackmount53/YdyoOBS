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
    public class HocaConfiguration : IEntityTypeConfiguration<Hoca>
    {
        public void Configure(EntityTypeBuilder<Hoca> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("HocaID");

            builder.Property(e => e.AdSoyad)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Adi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Aktiv).HasDefaultValueSql("((0))");

            builder.Property(e => e.Danisman).HasDefaultValueSql("((0))");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.EskiKulAdi)
                .HasColumnName("eski_KulAdi")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.EskiParola)
                .HasColumnName("eski_Parola")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.KayitTarih)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.Kisaltma)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.KulAdi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Parola)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ParolaDegisTarih).HasColumnType("datetime");

            builder.Property(e => e.Resim)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Sifre)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.SonGirisTarih).HasColumnType("datetime");

            builder.Property(e => e.Soyadi)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Yetki).HasDefaultValueSql("((0))");

            

        }
    }
}
