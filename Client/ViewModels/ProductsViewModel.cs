using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

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

    private void LoadProducts()
    {
        /*  var products = ProductServices.ListAllProducts();
         Products = new ObservableCollection<Product>(products); */ // create a new Observablecollection of the products list via its internal constructor
        Products = new ObservableCollection<Product>(ProductServices.ListAllProducts()); // same thing but in oneline 
    }
}
