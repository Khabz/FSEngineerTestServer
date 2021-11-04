using Assessment.Models.SearchModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assessment.Services
{
    public class SearchService
    {
        private readonly HttpClient _httpClient;

        public SearchService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<SearchResponseModel> Search(int query)
        {
            var chuckResponse = await _httpClient.GetAsync("search?query=" + query);
            chuckResponse.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<SearchResponseModel>(await chuckResponse.Content.ReadAsStreamAsync());
        }
    }
}
