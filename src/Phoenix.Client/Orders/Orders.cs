using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class Orders
    {
        private readonly HttpClient _client;
        public Orders(HttpClient client)
        {
            _client = client;
        }
        public async Task<GetAllOrdersResponse> GetAll(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/orders?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetAllOrdersResponse>();

            return result;
        }

        public async Task<GetOrderResponse> GetOrderById(long id)
        {
            var response = await _client.GetAsync(
                $"/api/orders/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetOrderResponse>();

            return result;
        }

        public async Task<GetOrderResponse> CreateOrder(CreateOrderRequest order)
        {
            var data = JsonConvert.SerializeObject(order);
            var response = await _client.PutAsync(
                "/api/orders", new StringContent(data, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetOrderResponse>();

            return result;
        }

        public async Task UpdateOrder(UpdateOrderRequest order)
        {
            var data = JsonConvert.SerializeObject(order);
            var response = await _client.PatchAsync(
                $"/api/orders/{order.Id}", new StringContent(data, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }
        
        public async Task DeleteOrder(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/orders/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}