using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phoenix.Client
{
    public class Products
    {
        private readonly HttpClient _client;
        public Products(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> GetAllProducts(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/products?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetProduct(long id)
        {
            var response = await _client.GetAsync(
                $"/api/products/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsStringAsync();

            return result;
        }
        
        public async Task DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/products/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}