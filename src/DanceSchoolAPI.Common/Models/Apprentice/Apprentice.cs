using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;
using DanceSchoolAPI.Common.Models.Students;

namespace DanceSchoolAPI.Common.Models.Apprentice;

[Table("dbo.Apprentices")]
public class Apprentice : User
{
    public override UserRole Role => UserRole.Apprentice;
    public DanceGroup DanceGroups { get; set; }
}
