using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
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
            _categoryService=categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var result = _categoryService.TGetListAll();
            return Ok(result);
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

            return Ok("Booking was successfully created.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _categoryService.TGetByID(id);

            _categoryService.TDelete(result);
            return Ok("Hakkımda Alanı Silindi.");
        }
        
        //public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        //{
        //    var category = new Category
        //    {
        //        Name = updateCategoryDto.Name,
        //        Status = updateCategoryDto.Status,
        //    };

        //    _categoryService.TUpdate(category);
        //    return Ok("Booking was successfully updated.");
        //}
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
            return Ok(result);
        }
       
    }
}

