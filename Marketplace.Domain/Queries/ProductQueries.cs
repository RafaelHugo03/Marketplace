using System.Linq.Expressions;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Queries
{
    public static class ProductQueries
    {
        public static Expression<Func<Product, bool>> GetById(Guid id)
        {
            return p => p.Id == id;
        }

        public static Expression<Func<Product, bool>> GetBySeller(Guid userSellerId)
        {
            return p => p.UserSellerId == userSellerId;
        }
    }
}