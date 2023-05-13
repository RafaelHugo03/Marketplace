using Marketplace.Domain.Commands.CategoryCommands;

namespace Marketplace.Domain.Validations.CommandValidations.CategoryCommands
{
    public class DeleteCategoryValidation : CategoryCommandValitadion<DeleteCategoryCommand>
    {
        public DeleteCategoryValidation()
        {
            ValidateId();
        }
    }
}