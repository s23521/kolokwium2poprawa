using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kolokwium2poprawa.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IDbService _dbService;
        public TeamController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{TeamID}")]
        public async Task<IActionResult> GetTeam(int TeamID)
        {
            return Ok(await _dbService.GetTeam(TeamID));
        }
    }
}