using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;
using DanceSchoolAPI.Common.Models.Students;

namespace DanceSchoolAPI.Common.Models.Teacher;

[Table("dbo.Teachers")]
public class Teacher : User
{
    public string DanceGroup { get; set; }
    new public string Role => "Teacher";
}
