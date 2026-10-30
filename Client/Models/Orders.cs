using System;
using System.Collections.Generic;

namespace Client.Models;

public record class Orders
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public required Customer Customer { get; set; }
    public List<OrderProduct> Items { get; set; } = [];
    public int TotalSum { get; set; }
}
