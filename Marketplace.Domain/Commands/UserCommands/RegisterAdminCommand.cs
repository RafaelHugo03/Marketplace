using Marketplace.Domain.Entities;
using Marketplace.Domain.enums;

namespace Marketplace.Domain.Commands.UserCommands
{
    public class RegisterAdminCommand : RegisterUserCommand
    {
        public RegisterAdminCommand(
            string name,
            string emailAddres,
            string password,
            DateTime birthDate) : base(name, emailAddres, password, birthDate) 
        {

        }

        public override User ToEntity()
        {
            return new(
                Guid.NewGuid(),
                this.Name,
                this.EmailAddress,
                this.Password,
                this.BirthDate,
                Role.Admin
            );
        }
    }
}