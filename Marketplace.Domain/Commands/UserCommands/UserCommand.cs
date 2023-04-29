using NetDevPack.Messaging;

namespace Marketplace.Domain.Commands.UserCommands
{
    public class UserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string EmailAddress { get; protected set; }
        public string Password { get; protected set; }
        public DateTime BirthDate { get; protected set; } 
    }
}