using Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product", "operation");

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("id")
                .HasColumnType("uuid");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.Description)
                .IsRequired(false)
                .HasColumnName("description")
                .HasColumnType("varchar")
                .HasMaxLength(500);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnName("price")
                .HasColumnType("decimal");

            builder.Property(p => p.Quantity)
                .IsRequired()
                .HasColumnName("quantity")
                .HasColumnType("int");

            builder.Property(p => p.UserSellerId)
                .IsRequired()
                .HasColumnName("user_seller_id")
                .HasColumnType("uuid");

            builder.HasOne(p => p.UserSeller)
                .WithMany()
                .HasForeignKey(p => p.UserSellerId);
        }
    }
}