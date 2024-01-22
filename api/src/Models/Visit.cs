using System;
using System.Data.Common;

namespace Api.Models;

public record Visit(Guid Id, string ConsultantName, DateTimeOffset Appointment)
{
    public static Visit FromReader(DbDataReader reader) => new(
        reader.GetGuid(0),
        reader.GetString(2),
        reader.GetFieldValue<DateTimeOffset>(3)
    );
}