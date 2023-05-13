using Marketplace.Domain.Entities;
using Marketplace.Domain.Validations.CommandValidations.CategoryCommands;

namespace Marketplace.Domain.Commands.CategoryCommands
{
    public class RegisterCategoryCommand : CategoryCommand
    {
        public RegisterCategoryCommand(
            string name
        )
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterCategoryValidation().Validate(this);
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