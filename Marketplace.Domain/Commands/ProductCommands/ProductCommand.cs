using NetDevPack.Messaging;

namespace Marketplace.Domain.Commands.ProductCommands
{
    public class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string? Description { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Price { get; protected set; }
        public Guid UserSellerId { get; protected set; }
    }
}