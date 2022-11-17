using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTips.NetCore7Ver.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        [HttpGet("Sample")]
        public async Task<IActionResult> SampleAsync()
        {
            return await Task.FromResult(Ok());
        }
    }
}
