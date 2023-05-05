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
        public List<OrderItem> OrderItems { get; private set; }
        public User UserBuyer { get; private set; }

        protected Order(){}

        public Order(Guid id,
            decimal totalPrice,
            Guid userBuyerId, 
            List<OrderItem> orderItems)
        {
            Id = id;
            OrderDate = DateTime.Now;
            UserBuyerId = userBuyerId;
            OrderItems = orderItems;
            TotalPrice = CalculateTotalPrice();
            Status = OrderStatus.PendingPayment;
        }

        public decimal CalculateTotalPrice() => OrderItems.Sum(s => s.Price);
        public void CancelOrder() => Status = OrderStatus.Canceled;
        public void PayOrder() => Status = OrderStatus.PendingPayment;
    }
}