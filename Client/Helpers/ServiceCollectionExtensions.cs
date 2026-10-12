using System;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Helpers;

public static class ServiceCollectionExtensions // utility file som hittar och mappar våra interfaces samt eve viewmodels
{
    public static void AddServices(this IServiceCollection collection)
    {


        collection.AddTransient<IProductService, ProductServices>(); // IF anyone ever wants the service then we give then the servoice
        collection.AddTransient<ICustomerService, CustomerServices>();
        collection.AddTransient<IOrderService, OrderServices>();
        // add all we are denpent on, that we want to get help to use
        collection.AddTransient<CustomersViewModel>();
        collection.AddTransient<OrdersViewModel>();
        collection.AddTransient<ProductsViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<SettingsViewModel>();
        collection.AddSingleton<MainWindowViewModel>(); // Create an instance of this class when app starts. Lives until app dies
    }
}

