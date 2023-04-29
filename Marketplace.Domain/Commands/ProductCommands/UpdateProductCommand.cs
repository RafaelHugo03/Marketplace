using Marketplace.Domain.Validations.CommandValidations.ProductCommands;

namespace Marketplace.Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(
            Guid id,
            string name,
            string? description,
            decimal price,
            int quanity
        )
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quanity;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}