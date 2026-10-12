using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Client.Helpers;
using Client.ViewModels;
using Client.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Client;

public partial class App : Application
{
    public override void Initialize() // runs the application with avalonia framework
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted() // avalonia frameworks is loaded run this
    {
        var collection = new ServiceCollection(); // bygger på interfacet ISrviceCollection
        collection.AddServices();
        var services = collection.BuildServiceProvider(); // this looks in colection which is all in the framweork that is a service, then build compile all that and put the result in services. IE paket all services and put them inservices to we can access them easily.
        var vm = services.GetRequiredService<MainWindowViewModel>(); // when the app starts we ask the service to give us what we want in this case the mainwidnowviewmodel take everytihgn in our servicecollectinoextension and pack into the services
        // initilize the new class where we use collectionservice        
        // tell the app that we are going to use the ViewModels as MainWindow class
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                // DataContext = new MainWindowViewModel() // Connect the ViewModel to the View  (if I want some other View on load then change this to that)
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}