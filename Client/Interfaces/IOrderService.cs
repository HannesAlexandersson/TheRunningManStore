using System;
using Client.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Client.ViewModels;
using Client.Services;


namespace Client.Interfaces;

public interface IOrderService
{
    Task Add(Orders order);
    Task Delete(string id);
    Task<OrderRestDb> Find(string itemNumber);
    Task<List<Orders>> List();
    Task Update(Orders order, string _objectId);
}