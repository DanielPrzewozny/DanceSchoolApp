using System.Threading.Tasks;
using DanceSchoolAPI.BaseControllers;
using DanceSchoolAPI.Common.Models.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FirstController : BaseCRUDEntityController<Teacher, FirstController>
{
    public FirstController(ILogger<FirstController> logger)
        : base(logger)
    {
    }
}