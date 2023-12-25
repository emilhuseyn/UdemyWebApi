using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyWebApi.Dal;
using UdemyWebApi.DTOs.CategoryDTOs;
using UdemyWebApi.Entities;
using UdemyWebApi.Services.Interfaces;


namespace UdemyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly AppDbContext _appDbContext;
        public CategoriesController(ICategoryService service, AppDbContext appDbContext)
        {
            _service = service;

            _appDbContext = appDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var result = await _service.GetByIdAsync(id);
            if (result is null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status200OK, result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto createDto)
        {

             _service.CreateAsync(createDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto updateDto)
        {
            if (updateDto.Id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var category = _service.GetByIdAsync(updateDto.Id);
            if (category is null) return StatusCode(StatusCodes.Status404NotFound);
            _service.UpdateAsync(updateDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            Category category = _appDbContext.Categories.Find(id);
            if (category is null) return StatusCode(StatusCodes.Status404NotFound);
             category.IsDeleted = true;
            _appDbContext.SaveChangesAsync();
            
            return StatusCode(StatusCodes.Status202Accepted);
        }

    }
}
