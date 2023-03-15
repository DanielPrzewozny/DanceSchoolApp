using System;
using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Models.Lesson;

[Table("dbo.Lessons")]
public class Lesson : EntityBaseDetails
{
    public string Name { get; set; }
    private TimeSpan timeEst;
    public string TimeEst { get => new DateTime(timeEst.Ticks).ToString("HH:mm"); set => timeEst = TimeSpan.Parse(value); }
    public string EverySpecificDayOfWeek { get; set; }
    public string DanceGroup { get; set; }
    public string Description { get; set; }
    public long TeacherId { get; set; }
}
