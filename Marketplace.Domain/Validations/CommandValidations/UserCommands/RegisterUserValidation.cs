using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Domain.Commands.UserCommands;

namespace Marketplace.Domain.Validations.CommandValidations.UserCommands
{
    public class RegisterUserValidation : UserCommandValidation<RegisterUserCommand>
    {
        public RegisterUserValidation()
        {
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}