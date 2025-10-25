using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var result = _categoryService.TGetListAll();
            return Ok(result);
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            return Ok(_categoryService.TPassiveCategoryCount());
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                Name = createCategoryDto.Name,
                Status = createCategoryDto.Status,
            };
            _categoryService.TAdd(category);
            return Ok("Category was successfully created.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.TGetByID(id);
            if (result == null) return NotFound();
            _categoryService.TDelete(result);
            return Ok("Category was successfully deleted.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDto dto)
        {
            var category = _categoryService.TGetByID(id);
            if (category == null) return NotFound();
            category.Name = dto.Name;
            category.Status = dto.Status;
            _categoryService.TUpdate(category);
            return Ok("Category updated successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var result = _categoryService.TGetByID(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
