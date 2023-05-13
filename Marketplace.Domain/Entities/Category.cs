using NetDevPack.Domain;

namespace Marketplace.Domain.Entities
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}