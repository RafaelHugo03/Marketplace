using NetDevPack.Domain;

namespace Marketplace.Domain.Entities
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string EmailAddress { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; } 
        public bool IsValidEmail { get; private set; } = false;

        public User(Guid id,
            string name, 
            string emailAddress, 
            string password, 
            DateTime birthDate)
        {
            Id = id;
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            BirthDate = birthDate;
        }

        public void UpdateUser(string name, 
            string emailAddress, 
            string password, 
            DateTime birthDate)
        {
            Name = name;
            EmailAddress = emailAddress;
            Password = password;
            BirthDate = birthDate;
        }

        public void ValidateEmail() => IsValidEmail = true;
    }
}