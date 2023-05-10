using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService;
        private readonly ITokenService tokenService;

        public ProductController(IProductService productService,
            ITokenService tokenService)
        {
            this.productService = productService;
            this.tokenService = tokenService;
        }

        [HttpGet("product-management/get-all")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await productService.GetAll());
        }

        [HttpGet("product-management/get-all/{id:guid}")]
        public async Task<IActionResult> GetAllByUser(Guid id)
        {
            return CustomResponse(await productService.GetAllByUser(id));
        }

        [HttpGet("product-management/get/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await productService.GetById(id));
        }

        [HttpPost("product-management/create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductDTO dto)
        {
            dto.UserSellerId = tokenService.GetIdInToken(Request);
            return CustomResponse(await productService.Register(dto));
        }

        [HttpPut("product-management/edit")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] ProductDTO dto)
        {
            return CustomResponse(await productService.Update(dto));
        }

        [HttpDelete("product-management/delete")]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] ProductDTO dto)
        {
            return CustomResponse(await productService.Delete(dto));
        }
    }
}