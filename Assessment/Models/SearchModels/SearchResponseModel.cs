using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assessment.Models.SearchModels
{
    public class SearchResponseModel
    {
        [JsonPropertyName("meta")]
        public string MetaData { get; set; }

        [JsonPropertyName("result")]
        public List<ChuckSearchResponseModel> ChuckResults { get; set; }

        [JsonPropertyName("results")]
        public List<SwapiPeopleResponseModel> SwapiResults { get; set; }
    }
}
