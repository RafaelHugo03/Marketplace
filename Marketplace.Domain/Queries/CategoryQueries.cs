using System.Linq.Expressions;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Queries
{
    public static class CategoryQueries
    {
        public static Expression<Func<Category, bool>> GetById(Guid id)
        {
            return c => c.Id == id;
        }
    }
}