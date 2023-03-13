using System.Threading.Tasks;
using DanceSchoolAPI.Common.Models.Students;
using DanceSchoolAPI.Common.Repositories.MSSQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DanceSchoolAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> logger;
    private readonly IMSSQLRepository<Student> mssqlRepository;

    public StudentController(
        ILogger<StudentController> logger,
        IMSSQLRepository<Student> mssqlRepository
        )
    {
        this.logger = logger;
        this.mssqlRepository = mssqlRepository;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(Student student)
    {
        await mssqlRepository.InsertAsync(student);
        return Ok();
    }
}