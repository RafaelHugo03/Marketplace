using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marketplace.Application.Models;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Commands.OrderCommands;
using Marketplace.Application.Utils;
using Marketplace.Domain.Commands.OrderItemCommands;

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
                    c.Password.StringHasher(),
                    c.BirthDate));

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
                    c.UserSellerId
                ));

            CreateMap<ProductDTO, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(
                    c.Id,
                    c.Name,
                    c.Description,
                    c.Price,
                    c.Quantity
                ));

            CreateMap<ProductDTO, DeleteProductCommand>()
                .ConstructUsing(c => new DeleteProductCommand(
                    c.Id
                ));

            CreateMap<OrderDTO, RegisterOrderCommand>()
                .ConstructUsing(c => new RegisterOrderCommand(
                    c.TotalPrice,
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
        }
    }
}