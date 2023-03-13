using DanceSchoolAPI.BaseControllers;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers.Apprentice;

[ApiController]
[Route("[controller]")]
public class ApprenticeController : BaseCRUDEntityController<User, ApprenticeController>
{
    public ApprenticeController(
        ILogger<ApprenticeController> logger,
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        : base(logger, commandDispatcher, queryDispatcher)
    {
    }
}