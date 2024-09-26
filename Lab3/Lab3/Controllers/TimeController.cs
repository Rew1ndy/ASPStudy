using Lab3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : Controller
    {
        private readonly TimeService _timeService;

        public TimeController(TimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public IActionResult GetDayTime()
        {
            return Ok(_timeService.GetDayTime());
        }
    }
}
