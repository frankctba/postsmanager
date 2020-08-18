using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PostsManager.LogsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;
        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            _logger.LogInformation($"GetAll (Information) endpoint visited at {DateTime.UtcNow.ToLongTimeString()}");
            _logger.LogError($"GetAll (Error) endpoint visited at {DateTime.UtcNow.ToLongTimeString()}");

            return Ok();
        }
    }
}
