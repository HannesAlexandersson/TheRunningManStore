using System;
using Client.Helpers;
using Client.Interfaces;
using Client.ViewModels;
// Denna här factoryn kommer att få addressen till en metod. Som vi kan använda för att skapa ett objekt ifrån en klass 
namespace Client.Factories;
// the func in constructor takes variable (pageFactory) that is a pointer to a method that theoreticly could be anywhere in the application that that takes the enum as argument and returns the pageviewmodel.
public class PageViewFactory(Func<ApplicationNameEnum, PageViewModel> pageFactory) : IPageViewFactory
{
    // LoadPageViewModel is a method that gets called BY whoever uses the INTERFACE, and inside the method pageFactory gets called that in turn runs the function (the func) it got as argument
    public PageViewModel LoadPageViewModel(ApplicationNameEnum pageName) => pageFactory.Invoke(pageName); // the factory creates an object using the enum we send into the constructor
                                                                                                          // the 'invoke' keyword means that we want to use the method that the variable (pagefactory) point to, becouse here we dont know exactl where it is or what its called. so we INVOKE whatever the variable points to
}


// what method is being called??? Its the singleton in the servicecollection extension method:  collection.AddSingleton<Func<ApplicationNameEnum, PageViewModel>>(c => name => name switch