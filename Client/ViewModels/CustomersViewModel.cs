using System;
using Client.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    // use the decorated property PageTitle from the base model
    public CustomersViewModel()
    {
        PageTitle = "Customer List";
    }

}
