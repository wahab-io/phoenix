using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class GetProductResponse
    {
        [JsonProperty]
        public long Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }
        
    }
}