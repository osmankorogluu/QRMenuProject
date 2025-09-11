using Newtonsoft.Json;

namespace QRMenuWebUI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [JsonProperty("categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

    }
}
