
using Marketplace.Domain.Validations.CommandValidations.UserCommands;
using SecureIdentity.Password;

namespace Marketplace.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id,
            string name,
            string emailAddres,
            string password,
            DateTime birthDate
        )
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddres;
            Password = password;
            BirthDate = BirthDate;
        }

        public void PasswordToHash() 
        {
            Password = PasswordHasher.Hash(this.Password);
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}