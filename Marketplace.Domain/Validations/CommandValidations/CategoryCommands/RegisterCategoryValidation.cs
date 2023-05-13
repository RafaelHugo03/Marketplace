using Marketplace.Domain.Commands.CategoryCommands;

namespace Marketplace.Domain.Validations.CommandValidations.CategoryCommands
{
    public class RegisterCategoryValidation : CategoryCommandValitadion<RegisterCategoryCommand>
    {
        public RegisterCategoryValidation()
        {
            ValidateName();
        }
    }
}