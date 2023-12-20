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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.OrderItems)
                  .WithOne()
                  .HasForeignKey<Basket>(b => b.OrderId)
                  .IsRequired();

            builder.Property(x => x.ShippingAddress).IsRequired();
            builder.Property(x => x.ShippingAddress).HasMaxLength(256);

            builder.Property(x => x.Payment).IsRequired();
            builder.Property(x => x.Payment).HasConversion<int>();

            builder.Property(x => x.OrderDate).IsRequired();

            builder.Property(x => x.OrderDate).IsRequired();
            builder.Property(x => x.OrderDate).HasConversion<DateTimeOffset>();

        }
    }
}
