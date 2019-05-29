using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class GetOrderResponse
    {
        [JsonProperty]
        public long Id { get; set; }
    }
}