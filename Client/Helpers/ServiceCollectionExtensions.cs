using System;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions // utility file som hittar och mappar våra interfaces samt eve viewmodels
{
    // en extension metod dvs en utökning, där vi lägger till en metod på en redan befintlig typ.
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>(); // Create an instance of this class when app starts. Lives until app dies
        collection.AddSingleton<PageViewFactory>(); // we need to register the factory as a service in order to use it. 
        // add all we are denpent on, that we want to get help to use
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<SettingsViewModel>();

        collection.AddTransient<IProductService, ProductServices>(); // IF anyone ever wants the service then we give then the servoice
        collection.AddTransient<ICustomerService, CustomerServices>();
        collection.AddTransient<IOrderService, OrderServices>();

        collection.AddSingleton<RestDBClient>();
        collection.AddTransient(typeof(IHttpService<>), typeof(HttpService<>));
        //collection.AddTransient<ISettingsService, SettingsService>();
        // before we always created the product/order/cust etc on start even though they are transient. This happens because the mainwindowviewmodel require them wich created and instance. so to get around this we need to start using pageviewmodels with constructor injection instead of using the viewmodels directly
        //the c is reference to teh servicecollection, name is the name of the page we want to create, and we use switch to match and return the correct thing. 
        // Func ---- vi lägger alltså tll metoden vid uppsstart så att den finns i minnet
        /*  collection.AddSingleton<Func<ApplicationNameEnum, PageViewModel>>(c => name => name switch //the first argument is a ref to the IServiceCollection interface... c => is outer lambda is used by DI to create the func<ApplicationNameEnum, PageViewMOdel> thats is used in teh constructor of pgageViewFactory... name => name switch is outer lambda that is the actual function that accepts a enumvalue and returns the correct pageviewmodel
         { //in the switch we check what 'name' is. If it is ApplicationNameEnum.Home for ex, then we want to CREATE and instance of the correct ViewModell!!
             ApplicationNameEnum.Home => c.GetRequiredService<HomeViewModel>(), // we enter into c (stands for serviceCollection) and use th GetRequiredService and ask that to give us the HomeViewModel
             ApplicationNameEnum.Customers => c.GetRequiredService<CustomersViewModel>(),
             ApplicationNameEnum.Orders => c.GetRequiredService<OrdersViewModel>(),
             ApplicationNameEnum.Products => c.GetRequiredService<ProductsViewModel>(),
             ApplicationNameEnum.Settings => c.GetRequiredService<SettingsViewModel>(),
             ApplicationNameEnum.AddNewProduct => c.GetRequiredService<AddNewProductViewModel>(),
             _ => throw new ArgumentException("It didnt work")
             /*  BAS SYNTAXEN BETYDER:
                 först får vi in en referens till våran service Collection. sen får vi namnet på sidan vi ska skapa
                 Eller viewmodellen vi ska skapa.  som vi sedan tittar på i Switch för att kunna returnera pageViewModel 
                 sen. DVS retur värdet är alltså rätt pageViewModel utifrån jämförelsen i switchen
             */
        /* }); */
    }
}

