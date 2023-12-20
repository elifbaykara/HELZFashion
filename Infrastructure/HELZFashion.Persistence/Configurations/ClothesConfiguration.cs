using HELZFashion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HELZFashion.Persistence.Configurations
{
    public class ClothesConfiguration : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder.HasOne(c => c.Brand)
                              .WithMany(b => b.Clothes)
                              .HasForeignKey(c => c.BrandId)
                              .IsRequired();

            builder.HasOne(c => c.Category)
                   .WithMany(cat => cat.Clothes)
                   .HasForeignKey(c => c.CategoryId)
                   .IsRequired();


            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(75);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(256);

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Price);

            builder.Property(x => x.Material).IsRequired();
            builder.Property(x => x.Material).HasMaxLength(75);

            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(75);


            builder.Property(x => x.ColorType).IsRequired();
            builder.Property(x => x.ColorType).HasConversion<int>();

            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Gender).HasConversion<int>();

            builder.Property(x => x.SizeType).IsRequired();
            builder.Property(x => x.SizeType).HasConversion<int>();

           
        }
    }
}
