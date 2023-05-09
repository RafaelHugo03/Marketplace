using Marketplace.Domain.enums;
using NetDevPack.Domain;

namespace Marketplace.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
    {
        public decimal TotalPrice { get; private set; }
        public DateTime OrderDate { get; private set; }
        public Guid UserBuyerId { get; private set; }
        public OrderStatus Status { get; private set; }
        public User UserBuyer { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        protected Order(){}

        public Order(Guid id,
            decimal totalPrice,
            Guid userBuyerId
        )
        {
            Id = id;
            OrderDate = DateTime.Now;
            UserBuyerId = userBuyerId;
            TotalPrice = totalPrice;
            Status = OrderStatus.PendingPayment;
        }
        public void CancelOrder() => Status = OrderStatus.Canceled;
        public void PayOrder() => Status = OrderStatus.PendingPayment;
    }
}