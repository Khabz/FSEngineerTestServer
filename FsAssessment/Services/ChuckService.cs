using FsAssessment.Entities.SearchEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FsAssessment.Services
{
    public class ChuckService
    {
        private readonly HttpClient _httpClient;

        public ChuckService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["ChuckServiceUrl"]);
        }

        public async Task<IList<string>> GetJokesCategoriesAsync()
        {

            var response = await _httpClient.GetAsync("jokes/categories");

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<IList<string>>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<JokeSearchResponse> SearchAsync(string query)
        {
            var response = await _httpClient.GetAsync("jokes/search?query=" + query);

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<JokeSearchResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
