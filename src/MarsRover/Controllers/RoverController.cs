using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsRover.Models;
using MarsRover.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : ControllerBase
    {
        private readonly ILogger<RoverController> _logger;
        private readonly IRoverService _roverService;

        public RoverController(ILogger<RoverController> logger, IRoverService roverService)
        {
            _logger = logger;
            _roverService = roverService;
        }

        [HttpPost("Deploy")]
        public IActionResult DeployRovers([FromBody] RoverRequest roverRequest)
        {
            return Ok(_roverService.DeployRovers(roverRequest));
        }
    }
}
