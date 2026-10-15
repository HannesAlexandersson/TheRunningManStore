using System;
using Avalonia.Controls;

namespace Client.ViewModels;

public class SettingsViewModel : PageViewModel
{
    public SettingsViewModel()
    {
        PageTitle = "Settings";
        PageName = Helpers.ApplicationNameEnum.Settings;
    }
}
