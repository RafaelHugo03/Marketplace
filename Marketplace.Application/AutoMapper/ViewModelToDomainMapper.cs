using AutoMapper;
using Marketplace.Application.Models;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Commands.OrderCommands;
using Marketplace.Domain.Commands.OrderItemCommands;
using Marketplace.Domain.Commands.CategoryCommands;

namespace Marketplace.Application.AutoMapper
{
    public class ViewModelToDomainMapper : Profile
    {
        public ViewModelToDomainMapper()
        {
            CreateMap<UserDTO, RegisterUserCommand>()
                .ConstructUsing(c => new RegisterUserCommand(
                    c.Name, 
                    c.EmailAddress,  
                    c.Password,
                    c.BirthDate));

            CreateMap<UserDTO, RegisterAdminCommand>()
                .ConstructUsing(c => new RegisterAdminCommand(
                    c.Name, 
                    c.EmailAddress,  
                    c.Password,
                    c.BirthDate));

            CreateMap<UserDTO, LoginCommand>()
                .ConstructUsing(c => new LoginCommand(
                    c.EmailAddress,
                    c.Password
                ));

            CreateMap<UserDTO, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(
                    c.Id,
                    c.Name, 
                    c.EmailAddress, 
                    c.Password,
                    c.BirthDate));

            CreateMap<UserDTO, DeleteUserCommand>()
                .ConstructUsing(c => new DeleteUserCommand(
                    c.Id
                ));

            CreateMap<ProductDTO, RegisterProductCommand>()
                .ConstructUsing(c => new RegisterProductCommand(
                    c.Name,
                    c.Description,
                    c.Price,
                    c.Quantity,
                    c.UserSellerId,
                    c.CategoryId
                ));

            CreateMap<ProductDTO, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(
                    c.Id,
                    c.Name,
                    c.Description,
                    c.Price,
                    c.Quantity,
                    c.CategoryId
                ));

            CreateMap<ProductDTO, DeleteProductCommand>()
                .ConstructUsing(c => new DeleteProductCommand(
                    c.Id
                ));

            CreateMap<OrderDTO, RegisterOrderCommand>()
                .ConstructUsing(c => new RegisterOrderCommand(
                    c.UserBuyerId,
                    c.OrderItems.Select(s => s.ToCommand()).ToList()
                ));

            CreateMap<OrderItemDTO, RegisterOrderItemCommand>()
                .ConstructUsing(c => new RegisterOrderItemCommand(
                    c.Id,
                    c.ProductId,
                    c.Quantity,
                    c.Price
                ));

            CreateMap<OrderDTO, CancelOrderCommand>()
                .ConstructUsing(c => new CancelOrderCommand(
                    c.Id
                ));

            CreateMap<OrderDTO, PayOrderCommand>()
                .ConstructUsing(c => new PayOrderCommand(
                    c.Id
                ));

            CreateMap<CategoryDTO, RegisterCategoryCommand>()
                .ConstructUsing(c => new RegisterCategoryCommand(
                    c.Name
                ));

            CreateMap<CategoryDTO, DeleteCategoryCommand>()
                .ConstructUsing(c => new DeleteCategoryCommand(
                    c.Id
                ));

            CreateMap<CategoryDTO, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(
                    c.Id,
                    c.Name
                ));
        }
    }
}