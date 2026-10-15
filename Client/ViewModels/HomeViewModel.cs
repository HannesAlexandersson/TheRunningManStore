using System;
using Avalonia.Controls;

namespace Client.ViewModels;

public class HomeViewModel : PageViewModel
{
    public HomeViewModel()
    {
        PageTitle = "Welcome to RunningManStore TM";
        PageName = Helpers.ApplicationNameEnum.Home;
    }
}
