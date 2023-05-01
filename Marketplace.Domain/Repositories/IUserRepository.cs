using Marketplace.Domain.Entities;
using NetDevPack.Data;

namespace Marketplace.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        void Create(User user);
        void Update(User user);
        Task<List<User>> GetUsers();
        Task<User> GetUser(Guid userId);
        Task<User> GetUserByEmail(string emailAddress);
        void Delete(User user);
    }
}