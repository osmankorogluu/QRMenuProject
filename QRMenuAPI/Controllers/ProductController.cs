using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

     
        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = _productService.TGetListAll();
            return Ok(result);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.Name 
            });
            return Ok(values.ToList());
        }

        
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.TGetByID(id);
            if (result == null)
                return NotFound("Ürün bulunamadı.");
            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var product = new Product
            {
                ProductName = createProductDto.ProductName,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                ImageUrl = createProductDto.ImageUrl,
                ProductStatus = createProductDto.ProductStatus
            };

            _productService.TAdd(product);
            return Ok("Ürün başarıyla oluşturuldu.");
        }

     
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = _productService.TGetByID(updateProductDto.ProductID);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            product.ProductName = updateProductDto.ProductName;
            product.Description = updateProductDto.Description;
            product.Price = updateProductDto.Price;
            product.ImageUrl = updateProductDto.ImageUrl;
            product.ProductStatus = updateProductDto.ProductStatus;

            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi.");
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            _productService.TDelete(product);
            return Ok("Ürün başarıyla silindi.");
        }
    }
}
