using Newtonsoft.Json;

namespace Store.Models
{
    public class CollectionDetailsModel
    {
        [JsonProperty("bgColor")]
        public string BgColor { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("fgColor")]
        public string FgColor { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("itemType")]
        public string ItemType { get; set; }
    }
}

