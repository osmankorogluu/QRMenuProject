using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _socialMediaService.TGetListAll();
            return Ok(result);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            if (value == null)
                return NotFound("Sosyal medya bulunamadı.");

            return Ok(value);
        }

      
        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto dto)
        {
            var socialMedia = new SocialMedia
            {
                Title = dto.Title,
                Url = dto.Url,
                Icon = dto.Icon
            };
            _socialMediaService.TAdd(socialMedia);

            return Ok("Sosyal medya başarıyla eklendi.");
        }

     
        [HttpPut]
        public IActionResult Update(UpdateSocailMediaDto dto)
        {
            var existing = _socialMediaService.TGetByID(dto.SocialMediaID);
            if (existing == null)
                return NotFound("Güncellenecek sosyal medya bulunamadı.");

            existing.Title = dto.Title;
            existing.Url = dto.Url;
            existing.Icon = dto.Icon;

            _socialMediaService.TUpdate(existing);
            return Ok("Sosyal medya başarıyla güncellendi.");
        }

   
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _socialMediaService.TGetByID(id);
            if (existing == null)
                return NotFound("Silinecek sosyal medya bulunamadı.");

            _socialMediaService.TDelete(existing);
            return Ok("Sosyal medya başarıyla silindi.");
        }
    }
}
