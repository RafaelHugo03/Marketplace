using Marketplace.Domain.Commands.OrderCommands;

namespace Marketplace.Domain.Validations.CommandValidations.OrderCommands
{
    public class RegisterOrderValidation : OrderCommandValidation<RegisterOrderCommand>
    {
        public RegisterOrderValidation()
        {
            ValidateUserBuyerId();
            ValidateProductIds();
            ValidateTotalPrice();
        }
    }
}