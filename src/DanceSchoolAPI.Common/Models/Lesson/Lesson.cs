using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Models.Lesson;

[Table("dbo.Lessons")]
public class Lesson
{
    public long Id { get; set; }
    public string Name { get; set; }
    public TimeSpan TimeEst { get; set; }
    public DayOfWeek EverySpecificDayOfWeek { get; set; }
    public DanceGroup DanceGroup { get; set; }
    public string Description { get; set; }
    public long TeacherId { get; set; }
}
