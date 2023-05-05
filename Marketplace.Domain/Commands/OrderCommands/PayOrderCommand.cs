using Marketplace.Domain.Validations.CommandValidations.OrderCommands;

namespace Marketplace.Domain.Commands.OrderCommands
{
    public class PayOrderCommand : OrderCommand
    {
        public PayOrderCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new PayOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}