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
    public class ChuckController : Controller
    {
        private readonly ChuckService _chuckService;

        public ChuckController(ChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Categories()
        {
            return Ok(await _chuckService.GetJokesCategoriesAsync());
        }
    }
}
