using Marketplace.Domain.Entities;
using Marketplace.Domain.enums;
using Marketplace.Domain.Validations.CommandValidations.UserCommands;
using SecureIdentity.Password;

namespace Marketplace.Domain.Commands.UserCommands
{
    public class RegisterUserCommand : UserCommand
    {
        public RegisterUserCommand(
            string name,
            string emailAddres,
            string password,
            DateTime birthDate
        )
        {
            Name = name;
            EmailAddress = emailAddres;
            Password = password;
            BirthDate = BirthDate;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterUserValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void PasswordToHash() 
        {
            Password = PasswordHasher.Hash(this.Password);
        }

        public virtual User ToEntity()
        {
            return new(
                Guid.NewGuid(),
                this.Name,
                this.EmailAddress,
                this.Password,
                this.BirthDate,
                Role.User
            );
        }
    }
}