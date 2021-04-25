using System;
using Newtonsoft.Json;

namespace GiphyWebApi.Models
{
    public class GiphyResult
    {
        [JsonProperty("data")]
        public GifData[] Data { get; set; }

        [JsonProperty("meta")]
        public Object Meta { get; set; }

        [JsonProperty("pagination")]
        public Object Pagination { get; set; }
    }
}