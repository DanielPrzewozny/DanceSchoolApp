using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Models.ClubCard;

[Table("dbo.ClubCards")]
public class ClubCard : EntityBaseDetails
{
    public long UserId { get; set; }
    public DanceGroup DanceGroup { get; set; }
    public List<long> LessonsIds { get; set; }
    public DateTimeOffset? ValidFromDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
}
