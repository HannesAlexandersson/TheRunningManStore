using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class CustomerServices : ICustomerService
{
    public async Task<List<Customer>> List()
    {
        /*  var storage = new Storage<Customer>();
         var path = string.Concat(Environment.CurrentDirectory, "/Data/customers.json");
         var products = storage.Read(path);

         return products; */

        var httpService = new HttpService<Customer>();
        var customers = await httpService.Get("customers");
        return customers;
    }
}
