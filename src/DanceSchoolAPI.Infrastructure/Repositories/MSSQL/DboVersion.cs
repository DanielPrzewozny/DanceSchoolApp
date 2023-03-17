﻿
using System.ComponentModel.DataAnnotations.Schema;
using DanceSchoolAPI.Common.Models;

namespace DanceSchoolAPI.Infrastructure.Repositories.MSSQL;

[Table("dbo.Version")]
public class DboVersion : EntityBaseDetails
{
    public long? Version { get; set; }
}
