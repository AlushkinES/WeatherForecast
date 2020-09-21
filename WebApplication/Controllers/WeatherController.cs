using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // private readonly ILogger<WeatherController> _logger;
        //
        // public WeatherController(ILogger<WeatherController> logger)
        // {
        //     _logger = logger;
        // }
        
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public ActionResult<List<Weather>> Get() =>
            _weatherService.Get();

    }
}