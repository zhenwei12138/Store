using System.ComponentModel;
using Newtonsoft.Json;

namespace Store.Models
{
    public partial class ProductModel
    {
        [JsonProperty("iconUrl")]
		public string IconUrl { set; get; }
        [JsonProperty("pdpImageUrl")]
        public string PdpImageUrl { set; get; }
        [JsonProperty("iconUrlBackground")]
        public string IconUrlBackground { set; get; }
        [JsonProperty("encodedTitle")]
        public string EncodedTitle { set; get; }
        [JsonProperty("displayPrice")]
        public string DisplayPrice { set; get; }
        [JsonProperty("averageRating")]
        public string AverageRating { set; get; }
        [JsonProperty("title")]
        public string Title { set; get; }

    }
}

