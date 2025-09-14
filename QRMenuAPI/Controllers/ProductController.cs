using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var values = _productService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var values = _productService.GetProductsWithCategory();
            var dto = _mapper.Map<List<ResultProductWithCategoryDto>>(values);
            return Ok(dto);
        }

        [HttpGet("{id:int}")]
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
            _productService.TAdd(new Product()
            {
                Description   = createProductDto.Description,
                ImageUrl      = createProductDto.ImageUrl,
                Price         = createProductDto.Price,
                ProductName   = createProductDto.ProductName,
                ProductStatus = createProductDto.ProductStatus,
                CategoryID    = createProductDto.CategoryID
            });
            return Ok("Ürün başarıyla eklendi.");
        }

        // 🔴 id parametresi route'ta tanımlandı
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto updateProductDto)
        {
            var product = _productService.TGetByID(id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            // ❌ product.ProductID set etmiyoruz
            product.ProductName   = updateProductDto.ProductName;
            product.Description   = updateProductDto.Description;
            product.Price         = updateProductDto.Price;
            product.ImageUrl      = updateProductDto.ImageUrl;
            product.ProductStatus = updateProductDto.ProductStatus;
            product.CategoryID    = updateProductDto.CategoryId;

            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id:int}")]
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
