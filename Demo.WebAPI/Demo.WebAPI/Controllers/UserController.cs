using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Lib.Infrastructure.Attribute;
using Demo.Lib.Models.Services;
using Demo.Lib.Services;

namespace Demo.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [CoreProfilingAsync("UserController.Create")]
        public IActionResult Create()
        {
            var param = new List<UserModel>()
            {
                new UserModel()
                {
                    Name = "Test01"
                }
            };
            var result = _userService.Create(param);
            return Ok(result);
        }
        [HttpGet]
        [CoreProfilingAsync("UserController.GetDetail")]
        public IActionResult GetDetail()
        {
            var param = new List<int>()
            {
                1,2,3,4,5,6
            };
            var result = _userService.GetDetail(param);
            return Ok(result);
        }
    }
}
