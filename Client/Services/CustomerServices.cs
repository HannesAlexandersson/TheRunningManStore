using System;
using System.Collections.Generic;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices
{
    public static List<Customer> ListAllCustomers()
    {
        var storage = new Storage<Customer>();
        var path = string.Concat(Environment.CurrentDirectory, "/Data/customers.json");
        var products = storage.Read(path);

        return products;
    }
}
