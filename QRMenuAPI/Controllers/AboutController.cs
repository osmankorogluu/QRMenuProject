using Microsoft.AspNetCore.Http;
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
            _aboutService=aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var result = _aboutService.TGetListAll();
            return Ok(result);
        }
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

            return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var result = _aboutService.TGetByID(id);

            _aboutService.TDelete(result);
            return Ok("Hakkımda Alanı Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var about = new About
            {
                AboutID = updateAboutDto.AboutID,
                ImageUrl = updateAboutDto.ImageUrl,
                title = updateAboutDto.title,
                Description = updateAboutDto.Description
            };

            _aboutService.TUpdate(about);
            return Ok("Hakkımda Alanı Başarılı Bir Şekilde Güncellendi.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var result = _aboutService.TGetByID(id);
            return Ok(result);
        }
    }
}
