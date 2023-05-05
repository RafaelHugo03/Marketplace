using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order", "operation");

            builder.Property(o => o.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(o => o.OrderDate)
                .IsRequired()
                .HasColumnName("order_date")
                .HasColumnType("timestamp without time zone");

            builder.Property(o => o.Status)
                .IsRequired()
                .HasColumnName("status")
                .HasColumnType("smallint");

            builder.Property(o => o.TotalPrice)
                .IsRequired()
                .HasColumnName("total_price")
                .HasColumnType("real");

            builder.Property(o => o.UserBuyerId)
                .IsRequired()
                .HasColumnName("user_buyer_id")
                .HasColumnType("uuid");

            builder.HasOne(o => o.UserBuyer)
                .WithMany()
                .HasForeignKey(o => o.UserBuyerId);

            builder.Ignore(oi => oi.OrderItems);
        }
    }
}