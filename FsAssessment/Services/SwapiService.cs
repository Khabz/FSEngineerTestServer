using FsAssessment.Entities.SearchEntities;
using FsAssessment.Entities.SwapiEntities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FsAssessment.Services
{
    public class SwapiService
    {
        private readonly HttpClient _httpClient;

        public SwapiService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(configuration["SwapiServiceUrl"]);
        }


        public async Task<PeopleResponse> GetPeopleAsync(int page)
        {
            var response = await _httpClient.GetAsync("people/?page=" + page);

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<PeopleResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<SwapiSearchResponse> SearchPeopleAsync(string query)
        {
            var response = await _httpClient.GetAsync("people/?search=" + query);

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<SwapiSearchResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}
