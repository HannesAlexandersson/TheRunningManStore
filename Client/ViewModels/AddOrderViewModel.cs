using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddOrderViewModel : ViewModelBase
{
    private readonly IOrderService _orderService;


    public AddOrderViewModel()
    {
        _orderService = new OrderServices();
        PageTitle = "Lägg till order";
    }
    [RelayCommand]
    private async Task AddOrder()
    {
        Orders order = new()
        {
            OrderId = Guid.NewGuid().ToString(),
            OrderDate = DateTime.UtcNow,
            Customer = new Customer()
            {
                FirstName = "Rune",
                LastName = "Andersson",
                Email = "Test@gmail.com",
                Phone = "0302-34333",
                AddressLine = "Testvägen 1",
                PostalCode = "44833",
                City = "Göteborg"
            },
            Items =
[
    new OrderProduct
{
    Product = new()
    {
        Id = Guid.NewGuid().ToString(),
        Description = "Test beskrivinging",
        ImageUrl = "www.test.se",
        ItemNumber = "123465",
        Name = "Test produkt",
        SupplierName = "Testbolaget",
        Price = 500
    },
    Quantity = 1,
    LineSum = 500
},
    new OrderProduct
    {
         Product = new(){
        Id = Guid.NewGuid().ToString(),
        Description = "Test beskrivinging2",
        ImageUrl = "www.test.se",
        ItemNumber = "23465645",
        Name = "Test produkt2",
        SupplierName = "Testbolaget2",
        Price = 600
         },
         Quantity = 1,
        LineSum = 600
    }
],
            TotalSum = 0
        };


        foreach (var item in order.Items)
        {
            order.TotalSum += item.LineSum;
        }

        await _orderService.Add(order);
    }
}