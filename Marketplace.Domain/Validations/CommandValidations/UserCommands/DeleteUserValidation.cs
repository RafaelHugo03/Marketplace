using Marketplace.Domain.Commands.UserCommands;

namespace Marketplace.Domain.Validations.CommandValidations.UserCommands
{
    public class DeleteUserValidation : UserCommandValidation<DeleteUserCommand>
    {
        public DeleteUserValidation()
        {
            ValidateId();
        }
    }
}