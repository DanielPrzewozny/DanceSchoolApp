using DanceSchoolAPI.BaseControllers;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.ClubCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClubCardController : BaseCRUDEntityController<ClubCard, ClubCardController>
{
    public ClubCardController(
        ILogger<ClubCardController> logger,
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        : base(logger, commandDispatcher, queryDispatcher)
    {
    }
}