using System;
using System.Collections.Generic;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;

namespace Client.Services;

public class OrderServices : IOrderService
{
    public List<Orders> List()
    {
        /*  var storage = new Storage<Orders>();
         var path = string.Concat(Environment.CurrentDirectory, "/Data/orders.json");
         var products = storage.Read(path);

         return products; */

        // we dont have any jsons documents anylonger so for now return an emoty array
        return [];
    }
}
