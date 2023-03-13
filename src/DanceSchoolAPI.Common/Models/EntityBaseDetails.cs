using DanceSchoolAPI.Common.Converters;
using Newtonsoft.Json;

namespace DanceSchoolAPI.Common.Models;
public class EntityBaseDetails
{
    public long Id { get; set; }

    public bool IsValid { get; set; } = true;

    [JsonConverter(typeof(ToUTCFormatConverter))]
    public DateTimeOffset? ModifiedOn { get; set; }

    public long? ModifiedBy { get; set; }

    [JsonConverter(typeof(ToUTCFormatConverter))]
    public DateTimeOffset CreatedOn { get; set; }

    public long CreatedBy { get; set; }
}
