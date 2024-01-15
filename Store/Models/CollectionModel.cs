using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Store.Models
{
    public class CollectionModel
	{
        [JsonProperty("title")]
		public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }
        [JsonProperty("curatedCollectionDetails")]
        public CollectionDetailsModel CuratedCollectionDetails { get; set; }
        [JsonProperty("productsList")]
        public ProductModel[] ProductsList { get; set; }

    }
}

