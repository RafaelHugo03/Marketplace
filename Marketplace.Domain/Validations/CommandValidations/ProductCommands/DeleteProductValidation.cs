using Marketplace.Domain.Commands.ProductCommands;

namespace Marketplace.Domain.Validations.CommandValidations.ProductCommands
{
    public class DeleteProductValidation : ProductCommandValidation<DeleteProductCommand>
    {
        public DeleteProductValidation()
        {
            ValidateId();
        }
    }
}