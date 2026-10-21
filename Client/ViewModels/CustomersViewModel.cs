using System;
using Client.Models;
using Client.ViewModels;
using Client.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Client.Interfaces;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class CustomersViewModel : PageViewModel
{
    private readonly ICustomerService _service;
    [ObservableProperty]
    public Customer? _selectedCustomer;
    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];

    // bara för previewen:
    public CustomersViewModel() { }
    public CustomersViewModel(ICustomerService service)
    {
        PageTitle = "Customer List"; // use the decorated property PageTitle from the base model
        _service = service;
        PageName = Enums.ApplicationNameEnum.Customers;
        LoadAllCustomers();
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
    private void LoadAllCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(_service.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
