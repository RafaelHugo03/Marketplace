using Marketplace.Domain.Entities;
using Marketplace.Domain.Validations.CommandValidations.ProductCommands;

namespace Marketplace.Domain.Commands.ProductCommands
{
    public class RegisterProductCommand : ProductCommand
    {
        public RegisterProductCommand(
            string name,
            string? description,
            decimal price,
            int quantity,
            Guid userSellerId,
            Guid categoryId
        )
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            UserSellerId = userSellerId;
            CategoryId = categoryId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Product ToEntity()
        {
            return new Product(
                this.Id,
                this.Name,
                this.Description,
                this.Price,
                this.Quantity,
                this.UserSellerId,
                this.CategoryId
            );
        }
    }
}