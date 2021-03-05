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
    public class BolumDurumConfiguration : IEntityTypeConfiguration<BolumDurum>
    {
        public void Configure(EntityTypeBuilder<BolumDurum> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("DurumID");

            builder.Property(e => e.Adi)
                .HasColumnName("Aciklama")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.ToTable("BolumDurum");
        }
    }
}
