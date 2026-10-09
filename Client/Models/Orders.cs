using System;

namespace Client.Models;

public record class Orders
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public Product Product { get; set; }
    public int TotalSum { get; set; }


    public void Edit()
    {

        Console.WriteLine("Edit clicked!");
    }
    public void Delete()
    {
        Console.WriteLine("Delete clicked!");
    }
}
