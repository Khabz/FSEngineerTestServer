using FsAssessment.Entities.SwapiEntities;
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
    public class SwapiController : Controller
    {
        private readonly SwapiService _swapiService;

        public SwapiController(SwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PeopleResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> People([FromQuery] int page)
        {
            return Ok(await _swapiService.GetPeopleAsync(page));
        }
    }
}
