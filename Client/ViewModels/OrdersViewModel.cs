using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using Client.Services;
using Client.Interfaces;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    private readonly IOrderService _services;

    [ObservableProperty]
    public partial ObservableCollection<Orders> Orders { get; set; } = [];
    public OrdersViewModel() { }
    public OrdersViewModel(IOrderService ordersService)
    {
        _services = ordersService;
        PageTitle = "Beställningar";
        Init();

    }

    private async void Init()
    {
        await LoadOrders();
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

    private async Task LoadOrders()
    {
        try
        {
            Orders = new ObservableCollection<Orders>(await _services.List());

        }
        catch (System.Exception)
        {

            throw;
        }
    }
}

