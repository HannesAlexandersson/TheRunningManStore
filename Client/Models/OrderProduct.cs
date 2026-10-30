using System;

namespace Client.Models;

public record OrderProduct
{
    public required Product Product { get; set; }
    public int Quantity { get; set; }
    public int LineSum { get; set; }
}