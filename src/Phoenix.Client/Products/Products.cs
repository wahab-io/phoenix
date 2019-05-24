using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class Products
    {
        private readonly HttpClient _client;
        public Products(HttpClient client)
        {
            _client = client;
        }
        public async Task<GetAllProductsResponse> GetAll(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/products?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetAllProductsResponse>();

            return result;
        }

        public async Task<GetProductResponse> GetProductById(long id)
        {
            var response = await _client.GetAsync(
                $"/api/products/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetProductResponse>();

            return result;
        }

        public async Task<GetProductResponse> CreateProduct(CreateProductRequest product)
        {
            var data = JsonConvert.SerializeObject(product);
            var response = await _client.PutAsync(
                "/api/products", new StringContent(data));
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetProductResponse>();

            return result;
        }

        public async Task UpdateProduct(UpdateProductRequest product)
        {
            var data = JsonConvert.SerializeObject(product);
            var response = await _client.PatchAsync(
                $"/api/products/{product.Id}", new StringContent(data));

            response.EnsureSuccessStatusCode();
        }
        
        public async Task DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/products/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}