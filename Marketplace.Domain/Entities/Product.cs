using System.ComponentModel.DataAnnotations.Schema;
using Marketplace.Core.Entities;
using NetDevPack.Domain;

namespace Marketplace.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public Guid UserSellerId { get; private set; }
        public User UserSeller { get; private set; }

        public Product(Guid id,
            string name, 
            string? description, 
            decimal price, 
            int quantity, 
            Guid userSellerId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            UserSellerId = userSellerId;
        }

        public void UpdateProduct(
            string name,
            string description,
            decimal price,
            int quantity
        )
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }
}