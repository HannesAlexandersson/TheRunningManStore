
using Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase // the base class is the one that inherits from observableobject now
{
    private readonly HomeViewModel _homeView;
    private readonly ProductsViewModel _productsView;
    private readonly SettingsViewModel _settingsView;
    private readonly OrdersViewModel _ordersView;
    private readonly CustomersViewModel _customersView;

    [ObservableProperty] // decorate the variable, remake it to an property somwhere behind the curtains, and let us get access to it anywhere OBS The class MUST be partial for this to work!!!
    public partial ViewModelBase CurrentView { get; set; } //  there exist an identical file somewhere udner the curtains that avalonia created for us, partial is for better performance 

    public MainWindowViewModel() { } // bara för designen preview ska fungera
    public MainWindowViewModel(SettingsViewModel settingsView, ProductsViewModel productsViewModel, HomeViewModel homeView, CustomersViewModel customersView, OrdersViewModel ordersView)
    {
        _productsView = productsViewModel;
        _homeView = homeView;
        _customersView = customersView;
        _ordersView = ordersView;
        _settingsView = settingsView;
        CurrentView = _homeView;
    }
    [RelayCommand] // this makes the toolkit mvvm to be able to take these methods, give them new names (GoToHomeCommand) and make them public so we can access them whereveer
    private void GoToHome() => CurrentView = _homeView;
    [RelayCommand]
    private void GoToProducts() => CurrentView = _productsView;
    [RelayCommand]
    private void GoToSettings() => CurrentView = _settingsView;

    [RelayCommand]
    private void GoToOrders() => CurrentView = _ordersView;

    [RelayCommand]
    private void GoToCustomers() => CurrentView = _customersView;
}
