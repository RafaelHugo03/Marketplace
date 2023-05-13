using Marketplace.Domain.Commands.CategoryCommands;

namespace Marketplace.Domain.Validations.CommandValidations.CategoryCommands
{
    public class UpdateCategoryValidation : CategoryCommandValitadion<UpdateCategoryCommand>
    {
        public UpdateCategoryValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}