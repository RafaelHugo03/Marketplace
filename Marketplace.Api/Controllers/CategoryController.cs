using Marketplace.Application.Models;
using Marketplace.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("category-management")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            return CustomResponse(await categoryService.GetAll());
        }

        [HttpGet("get/{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return CustomResponse(await categoryService.GetById(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryDTO dto)
        {
            return CustomResponse(await categoryService.Register(dto));
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit([FromBody] CategoryDTO dto)
        {
            return CustomResponse(await categoryService.Update(dto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryDTO dto)
        {
            return CustomResponse(await categoryService.Delete(dto));
        }
    }
}