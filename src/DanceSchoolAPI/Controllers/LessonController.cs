using DanceSchoolAPI.BaseControllers;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Lesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LessonController : BaseCRUDEntityController<Lesson, LessonController>
{
    public LessonController(
        ILogger<LessonController> logger,
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        : base(logger, commandDispatcher, queryDispatcher)
    {
    }
}