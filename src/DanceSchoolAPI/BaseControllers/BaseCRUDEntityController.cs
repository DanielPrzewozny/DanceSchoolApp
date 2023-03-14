using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DanceSchoolAPI.Common.CQRSElements.Commands;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.CRUDQueries;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.BaseControllers;

[ApiController]
[Route("[controller]")]
public class BaseCRUDEntityController<TEntity, TLoggerController> : CQDispatcherControllerBase
{
    protected readonly ILogger<TLoggerController> logger;

    public BaseCRUDEntityController(
        ILogger<TLoggerController> logger,
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        : base(commandDispatcher, queryDispatcher)
    {
        this.logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            TEntity entity = await QueryAsync<GetQuery<TEntity>, TEntity>(new GetQuery<TEntity>(id));
            logger.LogInformation("Get executed");
            return Json(entity);
        }
        catch (Exception ex)
        {
            var message = $"Id: {id}. Exception: {ex.Message}";
            logger.LogError($"Get exception: {ex.Message}");
            return BadRequest(ex);
        }
    }

    [HttpPost("Browse")]
    public async Task<IActionResult> Browse(BrowseQuery<TEntity> browseQuery)
    {
        try
        {
            IEnumerable<TEntity> browseResults = await QueryAsync<BrowseQuery<TEntity>, IEnumerable<TEntity>>(browseQuery);
            logger.LogInformation($"{nameof(TEntity)} - Browse executed");
            return Ok(browseResults);
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - Browse exception: {ex.Message}");
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("Create")]
    public async Task<IActionResult> Create(TEntity createdObject)
    {
        try
        {
            var id = await QueryAsync<CreateQuery<TEntity>, long>(new CreateQuery<TEntity>(createdObject));
            logger.LogInformation($"{nameof(TEntity)} - Create executed");
            return Created(string.Empty, id);
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
            await CommandAsync(new UpdateCommand<TEntity>(updateObject));
            logger.LogInformation($"{nameof(TEntity)} - Update executed");
            return Accepted();
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - {ex.Message}");
            return BadRequest(ex);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            await CommandAsync(new DeleteCommand<TEntity>(id));
            logger.LogInformation($"{nameof(TEntity)} - Delete executed");
            return Accepted();
        }
        catch (Exception ex)
        {
            logger.LogError($"{nameof(TEntity)} - {ex.Message}");
            return BadRequest(ex);
        }
    }
}