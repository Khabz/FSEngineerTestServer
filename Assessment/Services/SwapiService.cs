using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public class SwapiService
    {
        private readonly HttpClient _httpClient;

        public SwapiService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<SwapiPeopleResponseModel> GetPeopleAsync(int page)
        {
            var response = await _httpClient.GetAsync("people/?page=" + page);
            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<SwapiPeopleResponseModel>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<SwapiPeopleResponseModel> SearchPeople(string query)
        {
            var response = await _httpClient.GetAsync("people/?search=" + query);

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<SwapiPeopleResponseModel>(await response.Content.ReadAsStreamAsync());
        }
    }
}
