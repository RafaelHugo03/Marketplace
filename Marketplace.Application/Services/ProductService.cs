using AutoMapper;
using FluentValidation.Results;
using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Marketplace.Domain.Commands.ProductCommands;
using Marketplace.Domain.Commands.UserCommands;
using Marketplace.Domain.Repositories;
using NetDevPack.Mediator;

namespace Marketplace.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediator;

        public ProductService(IProductRepository productRepository, 
            IMapper mapper, 
            IMediatorHandler mediator)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            return mapper.Map<List<ProductDTO>>(await productRepository.GetAll());
        }

        public async Task<List<ProductDTO>> GetAllByUser(Guid id)
        {
            return mapper.Map<List<ProductDTO>>(await productRepository.GetAllByUser(id));
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            return mapper.Map<ProductDTO>(await productRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProductDTO dto)
        {
            var command = mapper.Map<RegisterProductCommand>(dto);
            return await mediator.SendCommand(command);
        }

        public async Task<ValidationResult> Update(ProductDTO dto)
        {
            var command = mapper.Map<UpdateProductCommand>(dto);
            return await mediator.SendCommand(command);
        }
    }
}