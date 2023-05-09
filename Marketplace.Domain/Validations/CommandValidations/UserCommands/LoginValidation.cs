using Marketplace.Domain.Commands.UserCommands;

namespace Marketplace.Domain.Validations.CommandValidations.UserCommands
{
    public class LoginValidation : UserCommandValidation<LoginCommand>
    {
        public LoginValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}