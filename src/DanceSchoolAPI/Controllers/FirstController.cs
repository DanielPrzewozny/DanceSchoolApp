using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FirstController : ControllerBase
{
    private readonly ILogger<FirstController> logger;

    public FirstController(ILogger<FirstController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        logger.LogInformation("Get successfully");
        return Ok();
    }
}