using Marketplace.Domain.enums;

namespace Marketplace.Application.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string? Password { get; set; }
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; }
    }
}
