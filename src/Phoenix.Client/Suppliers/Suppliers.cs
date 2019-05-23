using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phoenix.Client
{
    public class Suppliers
    {
        private readonly HttpClient _client;
        public Suppliers(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> GetAllSuppliers(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/suppliers?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsStringAsync();

            return result;
        }

        public async Task<string> GetSupplier(long id)
        {
            var response = await _client.GetAsync(
                $"/api/suppliers/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsStringAsync();

            return result;
        }
        
        public async Task DeleteSupplier(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/suppliers/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}