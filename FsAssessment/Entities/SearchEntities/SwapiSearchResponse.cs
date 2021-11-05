using FsAssessment.Entities.SwapiEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FsAssessment.Entities.SearchEntities
{
    public class SwapiSearchResponse
    {
        [JsonPropertyName("results")]
        public List<PersonResponse> People { get; set; }
    }
}
