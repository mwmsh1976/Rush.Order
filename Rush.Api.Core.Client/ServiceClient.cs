using Newtonsoft.Json;
using Rush.Api.Core.Client.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Rush.Api.Core.Client
{
    public class ServiceClient : IServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _client;
        private readonly string _clientName;

        public ServiceClient(IHttpClientFactory httpClientFactory, string clientName)
        {
            this._httpClientFactory = httpClientFactory;
            this._clientName = clientName;
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            T data;
            _client = _httpClientFactory.CreateClient(_clientName);
            _client.Timeout = new TimeSpan(0, 0, 0, 5, 0);
            try
            {
                using HttpResponseMessage response = await _client.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    using HttpContent content = response.Content;
                    string d = await content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PostAsync<T>(string endpoint, HttpContent postContent)
        {
            T data;
            _client = _httpClientFactory.CreateClient(_clientName);
            using (HttpResponseMessage response = await _client.PostAsync(endpoint, postContent))
                if (response.IsSuccessStatusCode)
                {
                    using HttpContent content = response.Content;
                    string d = await content.ReadAsStringAsync();
                    if (d != null)
                    {
                        data = JsonConvert.DeserializeObject<T>(d);
                        return (T)data;
                    }
                }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> PutAsync<T>(string endpoint, HttpContent putContent)
        {
            T data;
            _client = _httpClientFactory.CreateClient(_clientName);

            using (HttpResponseMessage response = await _client.PutAsync(endpoint, putContent))
            using (HttpContent content = response.Content)
            {
                string d = await content.ReadAsStringAsync();
                if (d != null)
                {
                    data = JsonConvert.DeserializeObject<T>(d);
                    return (T)data;
                }
            }
            Object o = new Object();
            return (T)o;
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            T newT;
            _client = _httpClientFactory.CreateClient(_clientName);

            using (HttpResponseMessage response = await _client.DeleteAsync(endpoint))
                if (response.IsSuccessStatusCode)
                {
                    using HttpContent content = response.Content;
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        newT = JsonConvert.DeserializeObject<T>(data);
                        return newT;
                    }
                }
            Object o = new Object();
            return (T)o;
        }

    }
}
