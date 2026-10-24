using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Client.Helpers;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class EditProductViewModel : ViewModelBase
{
    private readonly IProductService _service;
    private readonly string _itemNumber = string.Empty; // rekom stättet att göra det på
    private string _imageUrl = string.Empty;
    private string _objectId = string.Empty;
    [ObservableProperty]
    public partial string ItemNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Supplier { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int Price { get; set; } = 0;
    [ObservableProperty]
    public partial Bitmap? Image { get; set; } // it might no exist an image
    public EditProductViewModel()
    {
        _service = new ProductServices();
        PageTitle = "Uppdatera produkt: ";
    }
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
        _objectId = product._id;
        // _imageUrl = product.ImageUrl ?? "https://res.cloudinary.com/softtech-dev/image/upload/v1773483409/no-image_ymlpwk.png";
        _imageUrl = string.IsNullOrWhiteSpace(product.ImageUrl)
     || product.ImageUrl == "bild saknas"
         ? "https://res.cloudinary.com/softtech-dev/image/upload/v1773483409/no-image_ymlpwk.png"
         : product.ImageUrl;
        ItemNumber = product.ItemNumber;
        ProductName = product.Name;
        Supplier = product.SupplierName;
        Price = product.Price;
        // Image = product.ImageUrl is null ? null : await ImageHelper.ImageFromUrl(product.ImageUrl); // if url is null set to null else use the helper function to turn url to bitmap


        Image = await ImageHelper.ImageFromUrl(_imageUrl);
    }

    [RelayCommand]
    private async Task Save()
    {
        Product product = new()
        {
            ItemNumber = ItemNumber,
            Name = ProductName,
            SupplierName = Supplier,
            ImageUrl = _imageUrl,
            Description = "product updated",
            Price = Price
        };

        await _service.Update(product, _objectId);
    }
}
