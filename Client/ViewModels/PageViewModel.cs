using System;
using Client.Enums;
using Client.Helpers;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class PageViewModel : ViewModelBase // we have pageviewmodel to use to present the viewmodel, IE what page we present to the user. 
{
    [ObservableProperty]
    public partial ApplicationNameEnum PageName { get; set; }
}
