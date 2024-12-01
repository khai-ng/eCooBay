﻿namespace Ordering.API.Infrastructure.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasMany(x => x.OrderItems)
                .WithOne()
                .HasForeignKey(x => x.OrderId);
        }
    }
}
