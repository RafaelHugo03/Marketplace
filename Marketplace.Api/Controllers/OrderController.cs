using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService orderService;
        private readonly ITokenService tokenService;

        public OrderController(IOrderService orderService,
            ITokenService tokenService)
        {
            this.orderService = orderService;
            this.tokenService = tokenService;
        }

        [HttpGet("order-management/get-all")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await orderService.GetAll());
        }

        [HttpGet("order-management/get-all/{userBuyerId:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetAllByBuyer(Guid userBuyerId)
        {
            return CustomResponse(await orderService.GetAllByBuyer(userBuyerId));
        }

        [HttpGet("order-management/get-all/{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await orderService.GetById(id));
        }

        [HttpPost("order-management/create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] OrderDTO dto)
        {
            dto.UserBuyerId = tokenService.GetIdInToken(Request);
            return CustomResponse(await orderService.Register(dto));
        }

        [HttpPut("order-management/cancel-order")]
        [Authorize]
        public async Task<IActionResult> CancelOrder([FromBody] OrderDTO dto)
        {
            return CustomResponse(await orderService.Cancelorder(dto));
        }

        [HttpPut("order-management/pay-order")]
        [Authorize]
        public async Task<IActionResult> PayOrder([FromBody] OrderDTO dto)
        {
            return CustomResponse(await orderService.PayOrder(dto));
        }
    }
}