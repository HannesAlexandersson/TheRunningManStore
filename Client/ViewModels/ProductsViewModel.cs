using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    private IProductService _service;
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = []; // instead of generic list and array we use ObservableCollection for auto updating the collection whenever it changes

    public ProductsViewModel() { }
    public ProductsViewModel(IProductService service)
    {
        PageTitle = "Products";
        _service = service;
        LoadProducts();

    }
    /*   [RelayCommand]
      public void Edit()
      {
          Console.WriteLine("Edit clicked");
      }
      [RelayCommand]
      public void Delete()
      {
          Console.WriteLine("Delete clicked");
      } */
    private void LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(_service.List());

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
