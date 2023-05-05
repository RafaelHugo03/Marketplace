using NetDevPack.Messaging;

namespace Marketplace.Domain.Commands.OrderItemCommands
{
    public class OrderItemCommand : Command
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}