
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace CacheProxyServer
{
    internal class JCDecauxItem<T>
    {
        T item;

        public JCDecauxItem(string requestItem)
        {
            JCDecauxProxyManager jcdecaux = new JCDecauxProxyManager();
            Task<String> result = JCDecauxAPICall(requestItem);
            item = JsonConvert.DeserializeObject<T>(result.Result);
        }
        static async Task<string> JCDecauxAPICall(string request)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        internal T getItem()
        {
            return item;
        }
    }
}
