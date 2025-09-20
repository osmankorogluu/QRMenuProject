using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        // Tüm feature kayıtlarını getir
        [HttpGet]
        public IActionResult GetFeatures()
        {
            var result = _featureService.TGetListAll();
            return Ok(result);
        }

        // Tek bir feature getir
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var result = _featureService.TGetByID(id);
            if (result == null)
                return NotFound("Feature bulunamadı.");
            return Ok(result);
        }

        // Yeni Feature oluştur
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = new Feature
            {
                Title1 = createFeatureDto.Title1,
                Description1 = createFeatureDto.Description1,
                Title2 = createFeatureDto.Title2,
                Description2 = createFeatureDto.Description2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3
            };

            _featureService.TAdd(feature);
            return Ok("Feature başarıyla oluşturuldu.");
        }

        // Feature güncelle
        [HttpPut] // dikkat: burada {id} kullanılmıyor
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _featureService.TGetByID(updateFeatureDto.FeatureID);
            if (feature == null)
                return NotFound("Feature bulunamadı.");

            feature.Title1 = updateFeatureDto.Title1;
            feature.Description1 = updateFeatureDto.Description1;
            feature.Title2 = updateFeatureDto.Title2;
            feature.Description2 = updateFeatureDto.Description2;
            feature.Title3 = updateFeatureDto.Title3;
            feature.Description3 = updateFeatureDto.Description3;

            _featureService.TUpdate(feature);
            return Ok("Feature başarıyla güncellendi.");
        }

        // Feature sil
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _featureService.TGetByID(id);
            if (feature == null)
                return NotFound("Feature bulunamadı.");

            _featureService.TDelete(feature);
            return Ok("Feature başarıyla silindi.");
        }
    }
}
