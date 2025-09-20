using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var result = _discountService.TGetListAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var result = _discountService.TGetByID(id);
            if (result == null)
                return NotFound("Discount bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            var discount = new Discount
            {
                Title = createDiscountDto.Title,
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl
            };

            _discountService.TAdd(discount);
            return Ok(new { Message = "Discount başarıyla oluşturuldu.", discount });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDiscount(int id, UpdateDiscountDto updateDiscountDto)
        {
            var discount = _discountService.TGetByID(id);
            if (discount == null)
                return NotFound("Discount bulunamadı.");

            discount.Title = updateDiscountDto.Title;
            discount.Amount = updateDiscountDto.Amount;
            discount.Description = updateDiscountDto.Description;
            discount.ImageUrl = updateDiscountDto.ImageUrl;

            _discountService.TUpdate(discount);
            return Ok(new { Message = "Discount başarıyla güncellendi.", discount });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var discount = _discountService.TGetByID(id);
            if (discount == null)
                return NotFound("Discount bulunamadı.");

            _discountService.TDelete(discount);
            return Ok("Discount başarıyla silindi.");
        }
    }
}
