using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRMenuWebUI.Dtos.BookingDtos; // Booking DTO klasörünü ekledik
using System.Text;

namespace QRMenuWebUI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44366/api/Booking");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values ?? new List<ResultBookingDto>());
            }

            return View(new List<ResultBookingDto>());
        }

        // CREATE GET
        [HttpGet]
        public IActionResult CreateBooking()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
                return View(createBookingDto);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:44366/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(createBookingDto);
        }

        // DELETE
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44366/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        // UPDATE GET
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44366/api/Booking/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }

            return RedirectToAction("Index");
        }

        // UPDATE POST
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
                return View(updateBookingDto);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBookingDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Eğer API’de [HttpPut("{id}")] varsa:
            var responseMessage = await client.PutAsync(
                $"https://localhost:44366/api/Booking/{updateBookingDto.BookingID}",
                stringContent
            );

            // Eğer API’de sadece [HttpPut] varsa, üst satırı kapat ve aşağıyı aç:
            // var responseMessage = await client.PutAsync("https://localhost:44366/api/Booking", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(updateBookingDto);
        }
    }
}
