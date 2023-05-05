using Marketplace.Domain.Commands.OrderCommands;

namespace Marketplace.Domain.Validations.CommandValidations.OrderCommands
{
    public class CancelOrderValidation : OrderCommandValidation<CancelOrderCommand>
    {
        public CancelOrderValidation()
        {
            ValidateId();
        }
    }
}