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
            Guid userSellerId
        )
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            UserSellerId = userSellerId;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}