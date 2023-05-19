using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public AccountController(IUserService userService,
            ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpGet("user-management")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await userService.GetAll());
        }
        
        [HttpGet("user-management/{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await userService.GetById(id));
        }

        [HttpPost("user-management/login")]
        public async Task<IActionResult> Login([FromBody] UserDTO dto)
        {
            var response = await userService.Login(dto);

            if(!response.IsValid)
                return Unauthorized(response.Errors.Select(e => e.ErrorMessage));

            var user = await userService.GetByEmail(dto.EmailAddress);

            var token = tokenService.GenerateToken(user);

            return Ok(token);
        }
        
        [HttpPost("user-management/create")]
        public async Task<IActionResult> Create([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.Register(dto));
        }

        [HttpPost("user-management/create-admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.RegisterAdmin(dto));
        }

        [HttpPut("user-management/edit")]
        [Authorize]
        public async Task<IActionResult> Edit([FromBody] UserDTO dto)
        {
            dto.Id = tokenService.GetIdInToken(Request);
            return CustomResponse(await userService.Update(dto));
        }

        [HttpDelete("user-management/delete")]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody] UserDTO dto)
        {
            return CustomResponse(await userService.Delete(dto));
        }
    }
}