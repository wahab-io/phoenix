using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class CreateProductRequest
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Description { get; set; }
    }
}