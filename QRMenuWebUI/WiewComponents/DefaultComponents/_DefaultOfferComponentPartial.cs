using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRMenuWebUI.Dtos.DiscountDtos;
using QRMenuWebUI.Dtos.SliderDtos;
using System.Net.Http;

namespace QRMenuWebUI.WiewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Invoke() yerine InvokeAsync() kullanın
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44366/api/Discount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values ?? new List<ResultDiscountDto>());
            }

            return View(new List<ResultSliderDtos>());
        }
    }
    
    }

