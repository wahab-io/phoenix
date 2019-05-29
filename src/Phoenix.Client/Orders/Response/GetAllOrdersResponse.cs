using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class GetAllOrdersResponse
    {
        [JsonProperty]
        public IEnumerable<GetOrderResponse> Data { get; set; }
        
        [JsonProperty]
        public string Next { get; set; }

        [JsonProperty]
        public int Total { get; set; }
    }
}