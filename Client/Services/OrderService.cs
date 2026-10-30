using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.ViewModels;

namespace Client.Services;

public class OrderServices : IOrderService
{
    public async Task Add(Orders order)
    {
        var httpService = new HttpService<Orders>();
        await httpService.Post("orders", order);
    }

    public async Task Delete(string id)
    {
        var httpService = new HttpService<Orders>();
        await httpService.Delete("orders", id);
    }

    public async Task<OrderRestDb> Find(string itemNumber)
    {
        var httpService = new HttpService<OrderRestDb>();
        var searchCriteria = "{\"itemNumber\":" + "\"" + itemNumber + "\"}";
        return await httpService.Get("orders", searchCriteria);
    }

    public async Task<List<Orders>> List()
    {
        var httpService = new HttpService<Orders>();
        var orders = await httpService.Get("orders");
        return orders;
    }

    public async Task Update(Orders order, string _objectId)
    {
        var httpService = new HttpService<Orders>();
        await httpService.Put("orders", order, _objectId);
    }


}

public class OrderRestDb
{
}