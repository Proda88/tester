using System;
using Newtonsoft.Json;

namespace Part2_RestSharp_APITest.Model
{
    public class PlaceModel
    {
        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}

