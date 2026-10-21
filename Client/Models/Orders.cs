using System;
using System.Collections.Generic;

namespace Client.Models;

public record class Orders
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public List<Product> Products { get; set; } = [];
    public int TotalSum { get; set; }

}
