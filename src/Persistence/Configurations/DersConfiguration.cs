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
    public class DersConfiguration : IEntityTypeConfiguration<Ders>
    {
        public void Configure(EntityTypeBuilder<Ders> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("DersID");

            builder.Property(e => e.Adi)
              .HasColumnName("DersAdi")
              .IsRequired()
              .HasMaxLength(50)
              .IsUnicode(false);

            builder.Property(e => e.Aciklama)                
                  .HasMaxLength(50)
                  .IsRequired(false)
                  .IsUnicode(false);


        }
    }
}
