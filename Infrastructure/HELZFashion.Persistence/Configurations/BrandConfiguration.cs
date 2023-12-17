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
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasMany(b => b.Clothes)
                    .WithOne(c => c.Brand)
                    .HasForeignKey(c => c.BrandId)
                    .IsRequired();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(70);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(70);
        }
    }
}
