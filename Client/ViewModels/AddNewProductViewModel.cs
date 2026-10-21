using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddNewProductViewModel : PageViewModel
{
    public Product NewProduct { get; set; } = new()
    {
        ItemNumber = "",
        Name = "",
        SupplierName = "",
        Price = 0,
        Description = ""
    };
    private readonly IProductService _productService;
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = [];
    public AddNewProductViewModel()
    {
    }
    public AddNewProductViewModel(IProductService productService)
    {
        _productService = productService;
        PageTitle = "Lägg till en ny produkt";
        PageName = Enums.ApplicationNameEnum.AddNewProduct;
    }
    [RelayCommand]
    private void Save(string id)
    {
        Console.WriteLine("Lägg till produktens uppgifter, " + id);
        // AddProduct(id);
    }
    private async Task AddProduct(string id)
    {
        try
        {
            // use the POST method when its implemented to add the new product
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}