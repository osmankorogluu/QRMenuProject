using Newtonsoft.Json;

namespace QRMenuWebUI.Dtos.CategoryDtos
{
    public class ResultCategoryDto
    {
        [JsonProperty("categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("products")]
        public object Products { get; set; } // null da gelse JSON’da var
    }
}
