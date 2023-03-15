using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Enums;

namespace DanceSchoolAPI.Common.Models.Students;

public class User : EntityBaseDetails
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string ClubCardId { get; set; }
    public string Role { get; set; }
}
