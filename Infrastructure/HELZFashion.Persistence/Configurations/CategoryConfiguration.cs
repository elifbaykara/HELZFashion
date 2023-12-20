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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(x => x.Clothes)
                              .WithOne(c => c.Category)
                              .HasForeignKey(c => c.CategoryId)
                              .IsRequired();

            builder.Property(x => x.CategoryName)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(x => x.Gender)
                   .IsRequired()
                   .HasConversion<int>();

 

        }
    }
}
