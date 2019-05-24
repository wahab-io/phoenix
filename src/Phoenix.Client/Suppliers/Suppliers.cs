using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class Suppliers
    {
        private readonly HttpClient _client;
        public Suppliers(HttpClient client)
        {
            _client = client;
        }
        public async Task<GetAllSuppliersResponse> GetAll(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/suppliers?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetAllSuppliersResponse>();

            return result;
        }

        public async Task<GetSupplierResponse> GetSupplierById(long id)
        {
            var response = await _client.GetAsync(
                $"/api/suppliers/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetSupplierResponse>();

            return result;
        }

        public async Task<GetSupplierResponse> CreateSupplier(CreateSupplierRequest supplier)
        {
            var data = JsonConvert.SerializeObject(supplier);
            var response = await _client.PutAsync(
                "/api/suppliers", new StringContent(data));
            
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetSupplierResponse>();

            return result;
        }

        public async Task UpdateSupplier(UpdateSupplierRequest supplier)
        {
            var data = JsonConvert.SerializeObject(supplier);
            var response = await _client.PatchAsync(
                $"/api/suppliers/{supplier.Id}", new StringContent(data));

            response.EnsureSuccessStatusCode();
        }
        
        public async Task DeleteSupplier(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/suppliers/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}