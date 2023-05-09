using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Validations.CommandValidations.OrderCommands;

namespace Marketplace.Domain.Commands.OrderCommands
{
    public class RegisterOrderCommand : OrderCommand
    {
        public RegisterOrderCommand(
            Guid userBuyerId,
            List<RegisterOrderItemCommand> orderItems
        )
        {
            UserBuyerId = userBuyerId;
            OrderItems = orderItems;   
        }

        public void CalculateTotalPrice()
        {
            TotalPrice = this.OrderItems.Sum(oi => oi.Price);
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public Order ToEntity()
        {
            return new(Guid.NewGuid(), 
                this.TotalPrice, 
                this.UserBuyerId);
        }
    }
}