using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRMenuWebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace QRMenuWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44366/api/SocialMedia");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values ?? new List<ResultSocialMediaDto>());
            }

            return View(new List<ResultSocialMediaDto>());
        }

        // CREATE GET
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            if (!ModelState.IsValid)
                return View(createSocialMediaDto);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44366/api/SocialMedia", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(createSocialMediaDto);
        }

        // DELETE
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44366/api/SocialMedia/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        // UPDATE GET
        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44366/api/SocialMedia/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(value);
            }

            return RedirectToAction("Index");
        }

        // UPDATE POST
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            if (!ModelState.IsValid)
                return View(updateSocialMediaDto);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync(
                $"https://localhost:44366/api/SocialMedia/{updateSocialMediaDto.SocialMediaID}",
                stringContent
            );

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(updateSocialMediaDto);
        }
    }
}
