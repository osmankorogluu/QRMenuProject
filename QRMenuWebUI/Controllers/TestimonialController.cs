using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRMenuWebUI.Dtos.TestimonailoDtos; // Projende bu namespace kullanılıyorsa kalsın
using System.Text;

namespace QRMenuWebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync("https://localhost:44366/api/Testimonial");

            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(json);
                return View(values ?? new List<ResultTestimonialDto>());
            }

            TempData["Error"] = $"Listeleme hatası: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            return View(new List<ResultTestimonialDto>());
        }

        // CREATE GET
        [HttpGet]
        public IActionResult CreateTestimonial() => View();

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await client.PostAsync("https://localhost:44366/api/Testimonial", content);
            if (resp.IsSuccessStatusCode)
                return RedirectToAction("Index");

            TempData["Error"] = $"Ekleme hatası: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            return View(dto);
        }

        // DELETE
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.DeleteAsync($"https://localhost:44366/api/Testimonial/{id}");

            if (resp.IsSuccessStatusCode)
                return RedirectToAction("Index");

            TempData["Error"] = $"Silme hatası: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            return RedirectToAction("Index");
        }

        // UPDATE GET
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var resp = await client.GetAsync($"https://localhost:44366/api/Testimonial/{id}");

            if (resp.IsSuccessStatusCode)
            {
                var json = await resp.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(json);
                return View(value);
            }

            TempData["Error"] = $"GetById hatası: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            return RedirectToAction("Index");
        }

        // UPDATE POST
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // API [HttpPut("{id:int}")] ile uyumlu
            var resp = await client.PutAsync($"https://localhost:44366/api/Testimonial/{dto.TestimonialID}", content);

            if (resp.IsSuccessStatusCode)
                return RedirectToAction("Index");

            TempData["Error"] = $"Güncelleme hatası: {(int)resp.StatusCode} {resp.ReasonPhrase}";
            return View(dto);
        }
    }
}
