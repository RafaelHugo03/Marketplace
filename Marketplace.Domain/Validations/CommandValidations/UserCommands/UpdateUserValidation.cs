using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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