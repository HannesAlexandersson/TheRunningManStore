using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Markup.Xaml.Templates;
using Client.Interfaces;
using Client.Models;
using Client.Repositories;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;



namespace Client.ViewModels;

public partial class ProductsViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial bool ShowDialog { get; set; }
    private readonly IProductService? _service;
    private readonly MainWindowViewModel? _mainWindowVm;
    private string _productId = string.Empty;

    [ObservableProperty]
    public partial ObservableCollection<Product> Products { get; set; } = []; // instead of generic list and array we use ObservableCollection for auto updating the collection whenever it changes

    public ProductsViewModel()
    {
        PageTitle = "Products";
    }
    public ProductsViewModel(IProductService service, MainWindowViewModel mainWindowVm) // inject the mainwindowvm into this vm via the new pageviewfactory
    {
        PageTitle = "Products";
        _service = service;
        _mainWindowVm = mainWindowVm;
        Init();

    }
    [RelayCommand]
    public void Edit(string itemNumber)
    {
        Console.WriteLine("Edit clicked" + itemNumber);
    }
    [RelayCommand]
    public async Task Delete(string id)
    {
        try
        {
            _productId = id;
            _mainWindowVm!.IsBusy = true;
            ShowDialog = true;

        }
        catch (Exception ex)
        {

            Console.Write(ex.Message);
        }
    }
    [RelayCommand]
    private async Task Confirm()
    {
        ShowDialog = false;
        ProductRestDb product = await _service!.Find(_productId);
        if (product is not null)
        {
            await _service!.Delete(product._id);
            await LoadProducts();
        }

        _mainWindowVm!.IsBusy = false;
    }
    [RelayCommand]
    private void Cancel()
    {
        Console.WriteLine("Dont delete the product!");
        ShowDialog = false;
        _mainWindowVm!.IsBusy = false;
    }
    private async void Init() // think of this like a useEffect in react
    {
        await LoadProducts();
    }
    private async Task LoadProducts()
    {
        try
        {
            Products = new ObservableCollection<Product>(await _service!.List());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
