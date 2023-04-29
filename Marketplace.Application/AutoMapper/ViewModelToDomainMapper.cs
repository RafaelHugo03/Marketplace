using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marketplace.Application.Models;
using Marketplace.Core.Entities;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Commands.UserCommands;

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

            CreateMap<UserDTO, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(
                    c.Id,
                    c.Name, 
                    c.EmailAddress, 
                    c.Password,
                    c.BirthDate));

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
        }
    }
}