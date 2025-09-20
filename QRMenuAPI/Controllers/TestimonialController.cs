using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        // Senin interface adınla birebir: ITestoimonialService
        private readonly ITestoimonialService _testimonialService;

        public TestimonialController(ITestoimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // Listeleme
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _testimonialService.TGetListAll();
            return Ok(result);
        }

        // Tek kayıt
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var value = _testimonialService.TGetByID(id);
            if (value == null)
                return NotFound("Referans bulunamadı.");

            return Ok(value);
        }

        // Ekleme
        [HttpPost]
        public IActionResult Create([FromBody] CreateTestimonialDto dto)
        {
            if (dto == null)
                return BadRequest("İstek gövdesi boş olamaz.");

            var testimonial = new Testimonial
            {
                Name = dto.Name,
                Title = dto.Title,
                Comment = dto.Comment,
                ImageUrl = dto.ImageUrl,
                Status = dto.Status
            };

            _testimonialService.TAdd(testimonial);
            return Ok("Referans başarıyla eklendi.");
        }

        // Güncelleme (UI: PUT /api/Testimonial/{id})
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateTestimonialDto dto)
        {
            if (dto == null)
                return BadRequest("İstek gövdesi boş olamaz.");

            // Route id ile body id uyuşmazlığı kontrolü (body id geldiyse ve farklıysa hata)
            if (dto.TestimonialID != 0 && dto.TestimonialID != id)
                return BadRequest("Route Id ile gövdedeki Id uyuşmuyor.");

            var existing = _testimonialService.TGetByID(id);
            if (existing == null)
                return NotFound("Güncellenecek referans bulunamadı.");

            existing.Name = dto.Name;
            existing.Title = dto.Title;
            existing.Comment = dto.Comment;
            existing.ImageUrl = dto.ImageUrl;
            existing.Status = dto.Status;

            _testimonialService.TUpdate(existing);
            return Ok(existing); // Güncellenmiş kaydı döndürmek debug için faydalı
        }

        // Silme
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var existing = _testimonialService.TGetByID(id);
            if (existing == null)
                return NotFound("Silinecek referans bulunamadı.");

            _testimonialService.TDelete(existing);
            return Ok("Referans başarıyla silindi.");
        }
    }
}
