using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Models.Students;

namespace DanceSchoolAPI.Common.Models.Apprentice;

[Table("dbo.Apprentices")]
public class Apprentice : User
{
    public string DanceGroup { get; set; }
}
