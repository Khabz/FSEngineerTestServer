using Assessment.Models;
using Assessment.Models.SearchModels;
using Assessment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private readonly SwapiService _swapiService;
        private readonly ChuckNorriesService _chuckNorriesService;

        public SearchController(SwapiService swapiService, ChuckNorriesService chuckNorriesService)
        {
            _swapiService = swapiService;
            _chuckNorriesService = chuckNorriesService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            // Chuck api require more than 2 words when searching
            if(query.Length <= 2)
            {
                return BadRequest(new { message = "Search characters must be more than 2 word" });
            }
            //var swapiResponse = await _swapiService.SearchPeople(query);
            var chuckResponse = await _chuckNorriesService.SearchJoke(query);


            return Ok(new { chuckResponse.Id });
        }
    }
}
