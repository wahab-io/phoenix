using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class UpdateSupplierRequest
    {
        [JsonProperty]
        public long Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
    }
}