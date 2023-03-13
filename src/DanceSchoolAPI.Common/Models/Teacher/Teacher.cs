using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;
using DanceSchoolAPI.Common.Models.Students;

namespace DanceSchoolAPI.Common.Models.Teacher;

[Table("dbo.Teachers")]
public class Teacher : User
{
    public override UserRole Role => UserRole.Teacher;
    public DanceGroup DanceGroups { get; set; }
}
