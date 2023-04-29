using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Marketplace.Application.Models;
using Marketplace.Core.Entities;
using Marketplace.Domain.Entities;

namespace Marketplace.Application.AutoMapper
{
    public class DomainToViewModelMapper : Profile
    {
        public DomainToViewModelMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}