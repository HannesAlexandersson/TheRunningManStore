using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Client.ViewModels;
using System;

namespace Client;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null) return null; // early return null data is null

        var viewName = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.InvariantCulture); // find the viewmodel with the same name, replace the part of the name that is ViewModel with only View
        var view = Type.GetType(viewName); // use the viewName string, find it, load it into memory, check what type it is (presumably a class)
        if (view is null) return null; // if the type is null then eawrly exit
        var control = (Control)Activator.CreateInstance(view)!; // retype to Control type, and create instance 
        control.DataContext = data; // set the datacontext to the data from the argument list whatever that is
        return control;
    }

    public bool Match(object? data) => data is ViewModelBase; // controls if the type is of the viewmodelbase type

}
