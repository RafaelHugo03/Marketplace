using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.Models
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // public OrderItemDTO() { }

        // public OrderItemDTO(OrderItem orderItem)
        // {
        //     Id = orderItem.Id;
        //     OrderId = orderItem.OrderId;
        //     ProductId = orderItem.ProductId;
        //     Quantity = orderItem.Quantity;
        //     Price = orderItem.Price;
        // }

        // public static List<OrderItemDTO> ToEnumerable(
        //     List<OrderItem> orderItems
        // )
        // {
        //     return orderItems.Select(oi => new OrderItemDTO(oi)).ToList();
        // }

        public RegisterOrderItemCommand ToCommand()
        {
            return new (this.OrderId, this.ProductId, this.Quantity, this.Price);
        }
    }
}