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
            _discountService=discountService;
        }


        // Tüm indirimleri getir
        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var result = _discountService.TGetListAll();
            return Ok(result);
        }

        // Belirli bir indirimi getir
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var result = _discountService.TGetByID(id);
            if (result == null)
                return NotFound("Discount bulunamadı.");
            return Ok(result);
        }

        // Yeni Discount oluştur
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
            return Ok("Discount başarıyla oluşturuldu.");
        }

        // Discount güncelle
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            var discount = _discountService.TGetByID(updateDiscountDto.DiscountID);
            if (discount == null)
                return NotFound("Discount bulunamadı.");

            discount.Title = updateDiscountDto.Title;
            discount.Amount = updateDiscountDto.Amount;
            discount.Description = updateDiscountDto.Description;
            discount.ImageUrl = updateDiscountDto.ImageUrl;

            _discountService.TUpdate(discount);
            return Ok("Discount başarıyla güncellendi.");
        }

        // Discount sil
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
    // Change the access modifier of IDiscountService from internal to public
    // This interface must be declared as public in its definition file.
    // Example (in the file where IDiscountService is defined):

   
}
