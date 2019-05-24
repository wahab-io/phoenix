using System;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri, HttpContent content)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, requestUri);
            return await client.SendAsync(request);            
        }
    }
}