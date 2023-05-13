using Marketplace.Domain.Validations.CommandValidations.CategoryCommands;

namespace Marketplace.Domain.Commands.CategoryCommands
{
    public class DeleteCategoryCommand : CategoryCommand
    {
        public DeleteCategoryCommand(
            Guid id
        )
        {
            Id = id;   
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCategoryValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}