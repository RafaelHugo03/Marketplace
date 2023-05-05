using Marketplace.Domain.Validations.CommandValidations.OrderCommands;

namespace Marketplace.Domain.Commands.OrderCommands
{
    public class CancelOrderCommand : OrderCommand
    {
        public CancelOrderCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new CancelOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}