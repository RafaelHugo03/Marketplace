using System.Linq.Expressions;
using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Queries
{
    public static class OrderQueries
    {
        public static Expression<Func<Order, bool>> GetById(Guid id)
        {
            return o => o.Id == id;
        }

        public static Expression<Func<Order, bool>> GetByBuyerId(Guid userBuyerId)
        {
            return o => o.UserBuyerId == userBuyerId;
        }
    }
}