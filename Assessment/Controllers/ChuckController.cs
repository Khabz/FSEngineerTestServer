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
    public class ChuckController : Controller
    {
        private readonly ChuckNorriesService _chuckNorriesService;

        public ChuckController(ChuckNorriesService chuckNorriesService)
        {
            _chuckNorriesService = chuckNorriesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Categories()
        {
            return Ok(await _chuckNorriesService.GetJokesCategoriesAsync());
        }
    }
}
