using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Client.Interfaces;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class EditProductViewModel : ViewModelBase
{
    private readonly IProductService _service;
    private readonly string _itemNumber = string.Empty; // rekom stättet att göra det på
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;
    public EditProductViewModel(string itemNumber)
    {
        _service = new ProductServices();
        PageTitle = "Uppdatera produkt: " + itemNumber;
        _itemNumber = itemNumber;
    }
    public EditProductViewModel(string itemNumber, IProductService service)
    {
        PageTitle = "Uppdatera produkt: " + itemNumber;
        _service = service;
        _itemNumber = itemNumber;
        Init();
    }
    private async void Init()
    {
        await GetProduct();
    }
    private async Task GetProduct()
    {
        var product = await _service.Find(_itemNumber);
        Console.WriteLine(product);
        ProductName = product.Name;
    }
}
