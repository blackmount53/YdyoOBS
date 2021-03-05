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
    public class DonemConfiguration : IEntityTypeConfiguration<Donem>
    {
        public void Configure(EntityTypeBuilder<Donem> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("DonemID");
               
            
            builder.Property(e => e.Adi).HasColumnName("Donem")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Aktif)
                .HasColumnName("Aktiv")
                .HasDefaultValueSql("((0))");

        }
    }
}
