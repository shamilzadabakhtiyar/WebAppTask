using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTask.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("sync")]
        public IActionResult GetSync() 
        { 
            Thread.Sleep(1000);
            return Ok();
        }

        [HttpGet]
        [Route("async")]
        public async Task<IActionResult> GetAsync()
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
