using Marketplace.Domain.Entities;

namespace Marketplace.Domain.Commands.OrderItemCommands
{
    public class RegisterOrderItemCommand : OrderItemCommand
    {
        public RegisterOrderItemCommand(
            Guid productId,
            Guid orderId,
            int quantity,
            decimal price
        )
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            Price = price;
        }

        public OrderItem ToEntity()
        {
            return new(Guid.NewGuid(), 
                this.ProductId, 
                this.Quantity, 
                this.Price);
        }
    }
}