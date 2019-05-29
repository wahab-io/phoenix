using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phoenix.Client
{
    public class PhoenixClient
    {
        private readonly HttpClient _client;
        public PhoenixClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Add("User-Agent", "Phoenix-Client");
            _client = client;

            Customers = new Customers(_client);
            Suppliers = new Suppliers(_client);
            Products = new Products(_client);
            Orders = new Orders(_client);
        }

        public Customers Customers { get; }
        public Suppliers Suppliers { get; }
        public Products Products { get; }
        public Orders Orders { get; }
    }
}
