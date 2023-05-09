using Marketplace.Domain.Commands.UserCommands;

namespace Marketplace.Domain.Validations.CommandValidations.UserCommands
{
    public class UpdateUserValidation : UserCommandValidation<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            ValidateEmail();
            ValidateName();
            ValidateBirthDate();
            ValidateId();
        }
    }
}