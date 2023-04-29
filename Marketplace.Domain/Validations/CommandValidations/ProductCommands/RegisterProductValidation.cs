using Marketplace.Domain.Commands.ProductCommands;

namespace Marketplace.Domain.Validations.CommandValidations.ProductCommands
{
    public class RegisterProductValidation : ProductCommandValidation<RegisterProductCommand>
    {
        public RegisterProductValidation()
        {
            ValidateName();
            ValidatePrice();
            ValidateQuantity();
            ValidateUserSellerId();
        }
    }
}