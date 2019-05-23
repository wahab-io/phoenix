using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Phoenix.Client
{
    public class Customers
    {
        private readonly HttpClient _client;
        public Customers(HttpClient client)
        {
            _client = client;
        }
        public async Task<GetAllCustomersResponse> GetAll(int page = 1, int size = 25)
        {
            var response = await _client.GetAsync(
                $"/api/customers?page={page}&size={size}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetAllCustomersResponse>();

            return result;
        }

        public async Task<GetCustomerReponse> GetCustomerById(long id)
        {
            var response = await _client.GetAsync(
                $"/api/customers/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetCustomerReponse>();

            return result;
        }

        public async Task<GetCustomerReponse> CreateCustomer(CreateCustomerRequest customer)
        {
            var data = JsonConvert.SerializeObject(customer);
            var response = await _client.PutAsync(
                "/api/customers", new StringContent(data));

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<GetCustomerReponse>();

            return result;
        }

        public async Task UpdateCustomer(UpdateCustomerRequest request)
        {
            var data = JsonConvert.SerializeObject(request);
            var response = await _client.PutAsync(
                $"/api/customers/{request.Id}", new StringContent(data));

            response.EnsureSuccessStatusCode();
        }
        
        public async Task DeleteCustomer(long id)
        {
            var response = await _client.DeleteAsync(
                $"/api/customers/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}