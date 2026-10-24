using System;
using Client.Enums;
using Client.Helpers;
using Client.Interfaces;
using Client.Services;
using Client.ViewModels;
namespace Client.Factories;

public class PageViewFactory : IPageViewFactory
{

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        return pageName switch
        {
            PageViewsEnum.Home => new HomeViewModel(),
            PageViewsEnum.Products => new ProductsViewModel(new ProductServices()),
            PageViewsEnum.Customers => new CustomersViewModel(new CustomerServices()),
            PageViewsEnum.AddNewProduct => new AddNewProductViewModel(new ProductServices()),
            PageViewsEnum.Orders => new OrdersViewModel(new OrderServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };
    }
    public ViewModelBase LoadPageViewModel(PageViewsEnum page, string itemNumber)
    {
        return page switch
        {
            PageViewsEnum.EditProduct => new EditProductViewModel(itemNumber, new ProductServices()),
            _ => throw new InvalidOperationException("What ypu wanted could not be found"),
        };
    }

}


// what method is being called??? Its the singleton in the servicecollection extension method:  collection.AddSingleton<Func<ApplicationNameEnum, PageViewModel>>(c => name => name switch