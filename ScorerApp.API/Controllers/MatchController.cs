using System;
using Microsoft.AspNetCore.Mvc;
using ScorerApp.BLL.Services.Interfaces;

namespace ScorerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : Controller
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
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
    }
}
