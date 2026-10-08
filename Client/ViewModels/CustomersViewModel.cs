using System;
using Client.Models;
using Client.ViewModels;
using Client.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    [ObservableProperty]
    public Customer? _selectedCustomer;
    [ObservableProperty]
    public partial ObservableCollection<Customer> Customers { get; set; } = [];
    // use the decorated property PageTitle from the base model
    public CustomersViewModel()
    {
        PageTitle = "Customer List";

        LoadAllCustomers();
    }
    private void LoadAllCustomers()
    {
        /*  var customers = CustomerServices.ListAllCustomers();
         Customers = new ObservableCollection<Customer>; */
        Customers = new ObservableCollection<Customer>(CustomerServices.ListAllCustomers());
    }
}
