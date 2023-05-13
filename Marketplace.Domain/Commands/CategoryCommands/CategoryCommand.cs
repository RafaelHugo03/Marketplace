using NetDevPack.Messaging;

namespace Marketplace.Domain.Commands.CategoryCommands
{
    public class CategoryCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}