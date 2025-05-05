using e_commerce_web.Models.Domain;
using e_commerce_web.Models.Dto;
using e_commerce_web.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequestDto categoryRequestDto)
        {

            if (string.IsNullOrEmpty(categoryRequestDto.Name))
            {
                return BadRequest("Category name is required");
            }
            var categoryDomain = new Category()
            {
                Name = categoryRequestDto.Name
            };

            var createdCategory = await categoryRepository.CreateAsync(categoryDomain);

            return Ok();
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
        {
            var category = await categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryResponseDto = new GetCategoryByIdResponseDto()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Products = category.Products
            };
            return Ok(categoryResponseDto);
        }
    }
}
