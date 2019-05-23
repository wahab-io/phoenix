using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class GetCustomerReponse
    {
        [JsonProperty]
        public long Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Phone { get; set; }

        [JsonProperty]
        public string Fax { get; set; }

        [JsonProperty]
        public string City { get; set; }

        [JsonProperty]
        public string Country { get; set; }
        
    }
}