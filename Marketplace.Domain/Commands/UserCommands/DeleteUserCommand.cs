using Marketplace.Domain.Validations.CommandValidations.UserCommands;

namespace Marketplace.Domain.Commands.UserCommands
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}