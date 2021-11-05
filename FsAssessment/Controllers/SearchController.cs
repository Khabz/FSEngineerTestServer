using FsAssessment.Entities.SearchEntities;
using FsAssessment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FsAssessment.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private readonly SwapiService _swapiService;
        private readonly ChuckService _chuckService;

        public SearchController(SwapiService swapiService, ChuckService chuckService)
        {
            _swapiService = swapiService;
            _chuckService = chuckService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SearchResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchByQuery([FromQuery] string query)
        {
            if (query.Length <= 2)
            {
                return BadRequest(new { message = "Search characters must be more than 2 word" });
            }

            var chuckResponse = await _chuckService.SearchAsync(query);
            var swapiResponse = await _swapiService.SearchPeopleAsync(query);

            return Ok(new { people = swapiResponse.People, joke = chuckResponse.ChuckResponse });
        }
    }
}
