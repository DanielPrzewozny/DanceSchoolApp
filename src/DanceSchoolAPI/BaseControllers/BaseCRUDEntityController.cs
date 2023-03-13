using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.BaseControllers;

[ApiController]
[Route("[controller]")]
public class BaseCRUDEntityController<TEntity, TLoggerController> : Controller
{
    protected readonly ILogger<TLoggerController> logger;

    public BaseCRUDEntityController(
        ILogger<TLoggerController> logger)
    {
        this.logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            logger.LogInformation("Get executed");
            return Json(new object());
        }
        catch (Exception ex)
        {
            var message = $"Id: {id}. Exception: {ex.Message}";
            logger.LogError($"Get exception: {ex.Message}");
            return BadRequest(ex);
        }
    }

    [HttpPost("Browse")]
    public async Task<IActionResult> Browse()
    {
        try
        {
            logger.LogInformation($"{nameof(TEntity)} - Browse executed");
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - Browse exception: {ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(TEntity createdObject)
    {
        try
        {
            logger.LogInformation($"{nameof(TEntity)} - Create executed");
            return Ok(createdObject);
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - {ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(TEntity updateObject)
    {
        try
        {
            logger.LogInformation($"{nameof(TEntity)} - Update executed");
            return Accepted(updateObject);
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - {ex.Message}");
            return BadRequest(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            logger.LogInformation($"{nameof(TEntity)} - Delete executed");
            return Accepted(id);
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - {ex.Message}");
            return BadRequest(ex);
        }
    }
}