using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("user-management")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await userService.GetAll());
        }
        
        [HttpGet("user-management/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await userService.GetById(id));
        }

        [HttpPost("user-management/login")]
        public async Task<IActionResult> Login([FromBody] UserDTO dto, 
            [FromServices] ITokenService tokenService)
        {
            var response = await userService.Login(dto);

            if(!response.IsValid)
                return Unauthorized(response.Errors);

            var user = await userService.GetByEmail(dto.EmailAddress);

            var token = tokenService.GenerateToken(user);

            return Ok(token);
        }
        
        [HttpPost("user-management/create")]
        public async Task<IActionResult> Create([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.Register(dto));
        }

        [HttpPut("user-management/edit")]
        public async Task<IActionResult> Edit([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.Update(dto));
        }

        [HttpDelete("user-management/delete")]
        public async Task<IActionResult> Delete([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.Delete(dto));
        }
    }
}