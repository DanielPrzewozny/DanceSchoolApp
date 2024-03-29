using DanceSchoolAPI.BaseControllers;
using DanceSchoolAPI.Common.CQRSElements.Commands.Interfaces;
using DanceSchoolAPI.Common.CQRSElements.Queries.Interfaces;
using DanceSchoolAPI.Common.Models.Students;
using DanceSchoolAPI.Common.Models.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : BaseCRUDEntityController<Teacher, TeacherController>
{
    public TeacherController(
        ILogger<TeacherController> logger,
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
        : base(logger, commandDispatcher, queryDispatcher)
    {
    }
}