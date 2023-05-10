using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("order_item", "operation");

            builder.Property(oi => oi.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(oi => oi.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("real");

            builder.Property(oi => oi.Quantity)
                .IsRequired()
                .HasColumnName("quantity")
                .HasColumnType("int4");

            builder.Property(oi => oi.OrderId)
                .IsRequired()
                .HasColumnName("order_id")
                .HasColumnType("uuid");

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            builder.Property(oi => oi.ProductId)
                .IsRequired()
                .HasColumnName("product_id")
                .HasColumnType("uuid");

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);
        }
    }
}