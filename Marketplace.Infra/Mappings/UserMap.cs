using Marketplace.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marketplace.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user", "security");

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(u => u.EmailAddress)
                .IsRequired()
                .HasColumnName("email_address")
                .HasColumnType("varchar")
                .HasMaxLength(100);
            

            builder.Property(u => u.BirthDate)
                .IsRequired()
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder.Property(u => u.IsValidEmail)
                .IsRequired()
                .HasColumnName("is_valid_email")
                .HasColumnType("boolean")
                .HasDefaultValue(false);
        }
    }
}