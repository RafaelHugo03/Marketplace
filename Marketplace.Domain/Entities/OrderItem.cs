using System.ComponentModel.DataAnnotations.Schema;
using NetDevPack.Domain;

namespace Marketplace.Domain.Entities
{
    public class OrderItem : Entity, IAggregateRoot
    {
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Product Product { get; private set; }
        public Order Order { get; private set; }

        public OrderItem(
            Guid id, 
            Guid productId, 
            int quantity, 
            decimal price)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public void SetOrderId(Guid orderId) => OrderId = orderId;
    }
}