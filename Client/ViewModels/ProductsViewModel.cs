using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace Client.ViewModels;

public partial class ProductsViewModel : PageViewModel
{
    private readonly IProductService _service;
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = []; // instead of generic list and array we use ObservableCollection for auto updating the collection whenever it changes

    public ProductsViewModel() { }
    public ProductsViewModel(IProductService service) // when i start this class i say "I need this service becasue the service know how this class interface works. 
    {
        PageTitle = "Products";
        _service = service;
        PageName = Enums.ApplicationNameEnum.Products;
        Init();

    }
    [RelayCommand]
    public void Edit(string itemNumber)
    {
        Console.WriteLine("Edit clicked" + itemNumber);
    }
    [RelayCommand]
    public void Delete(string itemNumber)
    {
        Console.WriteLine("Delete clicked" + itemNumber);
    }

    private async void Init() // think of this like a useEffect in react
    {
        await LoadProducts();
    }
    private async Task LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(await _service.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
