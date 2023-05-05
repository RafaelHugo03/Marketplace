using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Entities;
using NetDevPack.Messaging;

namespace Marketplace.Domain.Commands.OrderCommands
{
    public class OrderCommand : Command
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid UserBuyerId { get; set; }
        public List<RegisterOrderItemCommand> OrderItems { get; set; }
    }
}