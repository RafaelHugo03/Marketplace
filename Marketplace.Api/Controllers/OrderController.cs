using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("order-management/get-all")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await orderService.GetAll());
        }

        [HttpGet("order-management/get-all/{userBuyerId:Guid}")]
        public async Task<IActionResult> GetAllByBuyer(Guid userBuyerId)
        {
            return CustomResponse(await orderService.GetAllByBuyer(userBuyerId));
        }

        [HttpGet("order-management/get-all/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await orderService.GetById(id));
        }

        [HttpPost("order-management/create")]
        public async Task<IActionResult> Create([FromBody] OrderDTO dto)
        {
            return CustomResponse(await orderService.Register(dto));
        }

        [HttpPut("order-management/cancel-order")]
        public async Task<IActionResult> CancelOrder([FromBody] OrderDTO dto)
        {
            return CustomResponse(await orderService.Cancelorder(dto));
        }

        [HttpPut("order-management/pay-order")]
        public async Task<IActionResult> PayOrder([FromBody] OrderDTO dto)
        {
            return CustomResponse(await orderService.PayOrder(dto));
        }
    }
}