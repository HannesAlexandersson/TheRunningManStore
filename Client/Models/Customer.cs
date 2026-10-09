using System;

namespace Client.Models;

public partial record class Customer
{
    public string CustomerId { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }

    public void Edit()
    {

        Console.WriteLine("Edit clicked!");
    }
    public void Delete()
    {
        Console.WriteLine("Delete clicked!");
    }
}
