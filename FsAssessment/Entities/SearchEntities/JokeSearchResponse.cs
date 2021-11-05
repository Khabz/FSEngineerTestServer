using FsAssessment.Entities.ChuckEntities;
using FsAssessment.Entities.SwapiEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FsAssessment.Entities.SearchEntities
{
    public class JokeSearchResponse
    {
        [JsonPropertyName("result")]
        public List<JokeResponse> ChuckResponse { get; set; }
    }
}
