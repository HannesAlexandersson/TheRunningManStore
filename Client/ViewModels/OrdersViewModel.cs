using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Client.Models;
using Client.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Client.Services;
using Client.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class OrdersViewModel : PageViewModel
{
    private readonly IOrderService _services;

    [ObservableProperty]
    public partial ObservableCollection<Orders> Orders { get; set; } = [];
    public OrdersViewModel() { }
    public OrdersViewModel(IOrderService services)
    {
        PageTitle = "ORDERS";
        _services = services;
        PageName = Enums.ApplicationNameEnum.Orders;
        LoadOrders();
    }

    [RelayCommand]
    public void Edit(string id)
    {
        Console.WriteLine("Edit clicked" + id);
    }
    [RelayCommand]
    public void Delete(string id)
    {
        Console.WriteLine("Delete clicked" + id);
    }

    private void LoadOrders()
    {
        try
        {
            Orders = new ObservableCollection<Orders>(_services.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
