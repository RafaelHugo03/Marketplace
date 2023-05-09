namespace Marketplace.Application.Models
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserBuyerId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
        public UserDTO UserBuyer { get; set; }
    }
}