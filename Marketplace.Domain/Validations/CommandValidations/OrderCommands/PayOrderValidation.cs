using Marketplace.Domain.Commands.OrderCommands;

namespace Marketplace.Domain.Validations.CommandValidations.OrderCommands
{
    public class PayOrderValidation : OrderCommandValidation<PayOrderCommand>
    {
        public PayOrderValidation()
        {
            ValidateId();
        }
    }
}