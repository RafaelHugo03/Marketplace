using Marketplace.Domain.Validations.CommandValidations.ProductCommands;

namespace Marketplace.Domain.Commands.ProductCommands
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteProductValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}