using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Client.Models;
using Client.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using Client.Services;
using Client.Interfaces;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    private IOrderService _services;

    [ObservableProperty]
    public partial ObservableCollection<Orders> Orders { get; set; } = [];
    public OrdersViewModel() { }
    public OrdersViewModel(IOrderService services)
    {
        PageTitle = "ORDERS";
        _services = services;
        LoadOrders();
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
