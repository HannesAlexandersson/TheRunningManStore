using System;
using Client.Models;
using Client.ViewModels;
using Client.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Client.Interfaces;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private ICustomerService _service;
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
        LoadAllCustomers();
    }
    private void LoadAllCustomers()
    {
        try
        {
            Customers = new ObservableCollection<Customer>(_service.List());
        }
        catch (Exception ex)
        {
            /* System.Diagnostics.Debug.WriteLine(ex.ToString());
            throw; */
            Console.WriteLine(ex.Message);
        }
    }
}
