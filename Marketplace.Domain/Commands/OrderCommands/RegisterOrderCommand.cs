using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Validations.CommandValidations.OrderCommands;

namespace Marketplace.Domain.Commands.OrderCommands
{
    public class RegisterOrderCommand : OrderCommand
    {
        public RegisterOrderCommand(
            decimal totalPrice,
            Guid userBuyerId,
            List<RegisterOrderItemCommand> orderItems
        )
        {
            TotalPrice = totalPrice;
            UserBuyerId = userBuyerId;
            OrderItems = orderItems;   
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
                this.UserBuyerId, 
                this.OrderItems.Select(s => s.ToEntity()).ToList());
        }
    }
}