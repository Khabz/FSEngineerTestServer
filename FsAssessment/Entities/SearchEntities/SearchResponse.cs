using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FsAssessment.Entities.SearchEntities
{
    public class SearchResponse
    {
        [JsonPropertyName("jokes")]
        public JokeSearchResponse Jokes { get; set; }

        [JsonPropertyName("people")]
        public SwapiSearchResponse People { get; set; }
    }
}
