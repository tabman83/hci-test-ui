using System;
using System.Data.Common;

namespace Api.Models;

public record Patient(Guid Id, string Name, ushort Age)
{
    public static Patient FromReader(DbDataReader reader) => new(
        reader.GetGuid(0),
        reader.GetString(1),
        reader.GetByte(2)
    );
}