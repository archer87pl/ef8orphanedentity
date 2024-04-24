using Microsoft.AspNetCore.Mvc;
using OrphanedEntities.Services;

namespace OrphanedEntities.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet(Name = "Check")]
        public async Task<IActionResult> Check()
        {
            await _testService.Check();

            return Ok();
        }
    }
}
