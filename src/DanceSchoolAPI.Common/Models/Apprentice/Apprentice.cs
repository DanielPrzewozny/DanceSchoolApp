using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Converters;
using DanceSchoolAPI.Common.Enums;
using DanceSchoolAPI.Common.Models.Students;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DanceSchoolAPI.Common.Models.Apprentice;

[Table("dbo.Apprentices")]
public class Apprentice : User
{
    public string DanceGroup { get; set; }
}
