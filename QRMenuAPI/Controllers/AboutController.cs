using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        // TÜM ABOUT KAYITLARI
        [HttpGet]
        public IActionResult GetAbouts()
        {
            var result = _aboutService.TGetListAll();
            return Ok(result);
        }

        // ID'YE GÖRE ABOUT GETİR
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var result = _aboutService.TGetByID(id);
            if (result == null)
                return NotFound("About bulunamadı.");

            return Ok(result);
        }

        // ABOUT EKLE
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var about = new About
            {
                ImageUrl = createAboutDto.ImageUrl,
                title = createAboutDto.title,
                Description = createAboutDto.Description
            };

            _aboutService.TAdd(about);
            return Ok("Hakkımda alanı başarılı bir şekilde eklendi.");
        }

        // ABOUT SİL
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var result = _aboutService.TGetByID(id);
            if (result == null)
                return NotFound("Silinecek About bulunamadı.");

            _aboutService.TDelete(result);
            return Ok("Hakkımda alanı silindi.");
        }

        // ABOUT GÜNCELLE
        [HttpPut("{id}")]
        public IActionResult UpdateAbout(int id, UpdateAboutDto updateAboutDto)
        {
            var about = new About
            {
                AboutID = id,
                ImageUrl = updateAboutDto.ImageUrl,
                title = updateAboutDto.title,
                Description = updateAboutDto.Description
            };

            _aboutService.TUpdate(about);
            return Ok("Hakkımda alanı başarılı bir şekilde güncellendi.");
        }
    }
}
