using System;

namespace Client.Models;

public record class Product // this should only be a simple data bearing 'record' nothing else!
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int Quantity { get; set; }
    public required string ItemNumber { get; set; }
    public required string Name { get; set; }
    public required string SupplierName { get; set; }
    public int Price { get; set; }
    // we delete the edit and dlete methods because this class should only be a databearing record!

}
