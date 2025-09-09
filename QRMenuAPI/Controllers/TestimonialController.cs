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
        private readonly ITestoimonialService _testimonialService;

        public TestimonialController(ITestoimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        // Tüm referansları getir
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _testimonialService.TGetListAll();
            return Ok(result);
        }

        // ID’ye göre getir
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _testimonialService.TGetByID(id);
            if (value == null)
                return NotFound("Referans bulunamadı.");

            return Ok(value);
        }

        // Yeni referans ekle
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto dto)
        {
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

        // Güncelle
        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto dto)
        {
            var existing = _testimonialService.TGetByID(dto.TestimonialID);
            if (existing == null)
                return NotFound("Güncellenecek referans bulunamadı.");

            existing.Name = dto.Name;
            existing.Title = dto.Title;
            existing.Comment = dto.Comment;
            existing.ImageUrl = dto.ImageUrl;
            existing.Status = dto.Status;

            _testimonialService.TUpdate(existing);
            return Ok("Referans başarıyla güncellendi.");
        }

        // Sil
        [HttpDelete("{id}")]
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
