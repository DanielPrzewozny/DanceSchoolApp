using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DanceSchoolAPI.Common.Models.Students;

[Table("dbo.StudentUsers")]
public class Student : EntityBaseDetails
{
    [Column("UserId")]
    new public long Id { get; set; } = -1;
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ClubCardId { get; set; }
}
