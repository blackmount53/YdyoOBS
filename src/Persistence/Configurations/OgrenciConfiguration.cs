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
    public class OgrenciConfiguration : IEntityTypeConfiguration<Ogrenci>
    {
        public void Configure(EntityTypeBuilder<Ogrenci> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("OgrID");

            builder.Property(e => e.OgrNo).HasMaxLength(15).IsUnicode(false);
            builder.Property(e => e.TCKimlikNo).HasColumnName("TCKimlikNo").HasMaxLength(11).IsUnicode(false);
            builder.Property(e => e.Adi).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.Soyadi).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.EvTel).HasMaxLength(14).IsUnicode(false);
            builder.Property(e => e.CepTel).HasMaxLength(14).IsUnicode(false);
            builder.Property(e => e.Eposta).HasMaxLength(255).IsUnicode(false);
            builder.Property(e => e.Cinsiyeti).HasMaxLength(10).IsUnicode(false).IsFixedLength();
            builder.Property(e => e.KayitTarihi).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.DegTarihi).HasColumnType("datetime");

            builder.Property(e => e.GirId).HasColumnName("GirID");
            builder.Property(e => e.DegId).HasColumnName("DegID");
            builder.Property(e => e.KurId).HasColumnName("KurID");
            builder.Property(e => e.DonemId).HasColumnName("DonemID");
            builder.Property(e => e.SinifId).HasColumnName("SinifID");
            builder.Property(e => e.Aktif).HasColumnName("Aktiv").IsRequired().HasDefaultValueSql("((1))");          
            builder.Property(e => e.IsDelete).HasDefaultValueSql("0");

            //Computed Columns
            builder.Property(e => e.FakulteAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GetFakulteAdiByOgrNo]([OgrNo]))");

            builder.Property(e => e.BolumAdi)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([dbo].[GetBolumAdiByOgrNo]([OgrNo]))");

            builder.Property(e => e.Devamsiz)
                .HasComputedColumnSql("([dbo].[GetDevamsizByDonemIDByOgrID]([DonemID],[OgrID]))");

            builder.Property(e => e.Ort)
                    .HasColumnType("decimal(5, 2)")
                    .HasComputedColumnSql("([dbo].[GetOrtalamaYuzdeyeGoreByDonemIDByOgrID]([DonemID],[OgrID]))");

            builder.Property(e => e.Ortalama)
                    .HasColumnType("decimal(5, 2)")
                    .HasComputedColumnSql("([dbo].[GetOrtalamaByDonemIDByOgrID]([DonemID],[OgrID]))");


            builder.Property(e => e.ToplamDevamsizlik)
                .HasComputedColumnSql("([dbo].[GetToplamDevamsizlikByDonemIDByOgrID]([DonemID],[OgrID]))");

        }
    }
}
