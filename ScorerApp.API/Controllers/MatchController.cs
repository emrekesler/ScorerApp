using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ScorerApp.BLL.Services.Interfaces;

namespace ScorerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        IConfiguration _configuration;
        public MatchController(IMatchService matchService, IConfiguration configuration)
        {
            _matchService = matchService;
            _configuration = configuration;
        }

        [HttpGet, Route("Get/{Id:int}")]
        public IActionResult Get(int Id)
        {
            return Json(_matchService.Get(Id));
        }

        [HttpGet, Route("Get/{date:DateTime}")]
        public IActionResult Get(DateTime date)
        {
            return Json(_matchService.Get(date));
        }

        [HttpGet, Route("Get/{Id:int}/{date:DateTime}")]
        public IActionResult Get(int Id, DateTime date)
        {
            return Json(_matchService.Get(Id, date));
        }

        [HttpGet, Route("Test")]
        public IActionResult Test()
        {
            return Ok(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
        }
        [HttpGet, Route("Test2")]
        public IActionResult Test2()
        {
            return Ok(_configuration["Env"]);
        }
        [HttpGet, Route("Test3")]
        public IActionResult Test3()
        {
            return Ok();
        }
    }
}
