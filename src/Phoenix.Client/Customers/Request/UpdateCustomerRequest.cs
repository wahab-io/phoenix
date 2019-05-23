using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class UpdateCustomerRequest
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
        public string AddressLine1 { get; set; }

        [JsonProperty]
        public string AddressLine2 { get; set; }

        [JsonProperty]
        public string City { get; set; }

        [JsonProperty]
        public string State { get; set; }

        [JsonProperty]
        public string ZipCode { get; set; }

        [JsonProperty]
        public string Country { get; set; }
    }
}