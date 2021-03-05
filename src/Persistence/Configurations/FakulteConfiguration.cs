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
    public class FakulteConfiguration : IEntityTypeConfiguration<Fakulte>
    {
        public void Configure(EntityTypeBuilder<Fakulte> builder)
        {
            builder.HasKey(e => e.FakulteNo);

            builder.Property(e => e.FakulteNo)
                .HasMaxLength(3)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Adi)
                .HasColumnName("Fakulte")
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasColumnName("Faculty")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
