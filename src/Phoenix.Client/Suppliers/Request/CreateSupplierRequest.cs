using System;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class CreateSupplierRequest
    {
        [JsonProperty]
        public string Name { get; set; }
    }
}