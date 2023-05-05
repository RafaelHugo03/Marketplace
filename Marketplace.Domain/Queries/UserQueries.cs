using System.Linq.Expressions;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetById(Guid id)
        {
            return u => u.Id == id;
        }

        public static Expression<Func<User, bool>> GetByEmail(string emailAddress)
        {
            return u => u.EmailAddress == emailAddress;
        }
    }
}