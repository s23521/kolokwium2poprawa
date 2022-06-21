using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models;
using kolokwium2poprawa.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kolokwium2poprawa.Controllers
{
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IDbService _dbService;
        public MemberController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(Member member)
        {
            await _dbService.AddMember(member);
            return Ok("New member added to database");
        }
    }
}