using Marketplace.Domain.Entities;
using Marketplace.Domain.Validations.CommandValidations.CategoryCommands;

namespace Marketplace.Domain.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : CategoryCommand
    {
        public UpdateCategoryCommand(
            Guid id,
            string name
        )
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCategoryValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Category ToEntity()
        {
            return new Category(
                this.Id,
                this.Name
            );
        }
    }
}