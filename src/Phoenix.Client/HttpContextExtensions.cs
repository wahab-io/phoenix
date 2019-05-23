using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpExtensions
    {
        public static async Task<TEntity> ReadAsAsync<TEntity>(this HttpContent content)
        {
            return JsonConvert.DeserializeObject<TEntity>(await content.ReadAsStringAsync());
        }
    }
}