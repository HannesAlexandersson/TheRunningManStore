using System;
using Client.Enums;
using Client.Interfaces;
using Client.ViewModels;

namespace Client.Factories;

public class PageViewFactory : IPageViewFactory
{ // this class will need a argument that is a function
  // func and action is a way to send an address to a function as a argument

    // we send in a pageviewsenum, adn we want OUT is something that inhereits from viewmodelbase (a viewmodel). This is an anonym not known function that takes a pageviewenum and returns basicly a vm
    private readonly Func<PageViewsEnum, ViewModelBase> _pageFactory;
    public PageViewFactory(Func<PageViewsEnum, ViewModelBase> pageFactory)
    {
        _pageFactory = pageFactory; // we place the anon function in the private field _pageFacotry
    }

    public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        // we call the anon function from the field pagefactory
        return _pageFactory.Invoke(pageName); // invoke basicly means "run the method", this method we call returns a viewmodelbase object (a vm)
    }
}
/* OLD CODE we dont want to have it create new services etc... this is not real DI

public ViewModelBase LoadPageViewModel(PageViewsEnum pageName)
    {
        return pageName switch
        {
            PageViewsEnum.Home => new HomeViewModel(),
            PageViewsEnum.Products => new ProductsViewModel(new ProductServices()),
            PageViewsEnum.Customers => new CustomersViewModel(new CustomerServices()),
            PageViewsEnum.AddProduct => new AddNewProductViewModel(new ProductServices()),
            PageViewsEnum.Orders => new OrdersViewModel(new OrderServices()),
            PageViewsEnum.AddOrder => new AddOrderViewModel(),
            PageViewsEnum.Settings => new SettingsViewModel(),
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
 */
