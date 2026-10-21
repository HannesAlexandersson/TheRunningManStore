
using Client.Factories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class MainWindowViewModel : ViewModelBase // the base class is the one that inherits from observableobject now
{
    private readonly PageViewFactory _factory;
    [ObservableProperty] // decorate the variable, remake it to an property somwhere behind the curtains, and let us get access to it anywhere OBS The class MUST be partial for this to work!!!
    public partial ViewModelBase CurrentView { get; set; } = new(); //  there exist an identical file somewhere udner the curtains that avalonia created for us, partial is for better performance 

    public MainWindowViewModel() { } // bara för designen preview ska fungera

    // OBS PÅ FREDAG SKA VI GÖRA OM DETTA TILL ETT INTERFACE ISTÄLLET FÖR ATT TA IN FACTORYN I KONSTRUKTORN!!!
    public MainWindowViewModel(PageViewFactory factory) // before when we had all the viewmodels in this constructor it caused all viewmodels to load on start even though they are transient services, so instead we remved all viewmodels and start using constructor injection to get what we need WHEN we need it instead
    {
        _factory = factory;
        GoToHome();
    }
    [RelayCommand] // this makes the toolkit mvvm to be able to take these methods, give them new names (GoToHomeCommand) and make them public so we can access them whereveer
    private void GoToHome() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.Home);
    [RelayCommand]
    private void GoToProducts() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.Products);
    [RelayCommand]
    private void GoToSettings() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.Settings);

    [RelayCommand]
    private void GoToOrders() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.Orders);

    [RelayCommand]
    private void GoToCustomers() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.Customers);
    [RelayCommand]
    private void GoToAddProduct() => CurrentView = _factory.LoadPageViewModel(Enums.ApplicationNameEnum.AddNewProduct);
}
