using System;

namespace Client.Models;

public record OrderRestDb : Orders
{
    public string _id { get; set; } = string.Empty;
}