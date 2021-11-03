using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public class ChuckNorriesService
    {
        private readonly HttpClient _httpClient;

        public ChuckNorriesService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IList<string>> GetJokesCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("jokes/categories");
            response.EnsureSuccessStatusCode();
            return await JsonSerializer.DeserializeAsync<IList<string>>(await response.Content.ReadAsStreamAsync());
        }
    }
}
