using AutoMapper;
using Marketplace.Application.Models;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.AutoMapper
{
    public class DomainToViewModelMapper : Profile
    {
        public DomainToViewModelMapper()
        {
            CreateMap<User, UserDTO>().AfterMap((src, dest) => dest.Password = "");
            CreateMap<Product, ProductDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Order, OrderDTO>();
        }
    }
}