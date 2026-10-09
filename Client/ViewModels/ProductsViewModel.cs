using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Repositories;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = []; // instead of generic list and array we use ObservableCollection for auto updating the collection whenever it changes
    public ProductsViewModel()
    {
        PageTitle = "Products";
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
        /*  var products = ProductServices.ListAllProducts(); // create a new Observablecollection of the products list via its internal constructor
         Products = new ObservableCollection<Product>(products); 
         */
        try
        {
            Products = new ObservableCollection<Product>(ProductServices.ListAllProducts()); // same thing but in oneline 

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
