using System;
using Client.Enums;
using Client.Helpers;
using Client.ViewModels;

namespace Client.Interfaces;

public interface IPageViewFactory // the interface only job is to return the correct viewmodel
{
    PageViewModel LoadPageViewModel(ApplicationNameEnum pageName); // load the pageviewmodel with the enum with correct pagename
}
