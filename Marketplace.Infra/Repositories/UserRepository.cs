using Marketplace.Domain.Entities;
using Marketplace.Domain.Queries;
using Marketplace.Domain.Repositories;
using Marketplace.Infra.Data;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace Marketplace.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MarketplaceContext Db;
        private readonly DbSet<User> DbSet;

        public UserRepository(MarketplaceContext context)
        {
            Db = context;
            DbSet = context.Set<User>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Create(User user)
        {
            DbSet.Add(user);
        }

        public void Delete(User user)
        {
            DbSet.Remove(user);
        }

        public void Dispose()
        {
            Db.Dispose();
        }


        public async Task<User> GetUser(Guid userId)
        {
            return await DbSet.FirstOrDefaultAsync(UserQueries.GetById(userId));
        }

        public async Task<User> GetUserByEmail(string emailAddress)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(UserQueries.GetByEmail(emailAddress));
        }

        public async Task<List<User>> GetUsers()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public void Update(User user)
        {
            DbSet.Update(user);
        }
    }
}