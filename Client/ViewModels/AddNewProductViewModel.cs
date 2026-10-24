using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddNewProductViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string ItemNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Name { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Supplier { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int Price { get; set; }
    private readonly IProductService _productService;
    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = [];
    // endast för design och preview , detta ska bort sedan nör vi inte behöver preview längre!
    // TODO: Ta bort!
    public AddNewProductViewModel()
    {
        _productService = new ProductServices();
        PageTitle = "Lägg till en ny produkt";
    }
    /* **************************************************** */
    public AddNewProductViewModel(IProductService productService)
    {
        _productService = productService;
        PageTitle = "Lägg till en ny produkt";

    }
    [RelayCommand]
    private async Task Save(string id)
    {
        // AddProduct(id);
        // först validera inputten


        Product product = new()
        {
            ItemNumber = ItemNumber,
            Name = Name,
            SupplierName = Supplier,
            ImageUrl = "bild saknas",
            Description = "Ny produktbeskrivning",
            Price = Price,
        };
        await _productService.Add(product);
    }
    [RelayCommand]
    private void Abort()
    {
        Console.WriteLine("Avbryt att lägga till ny produkt");
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