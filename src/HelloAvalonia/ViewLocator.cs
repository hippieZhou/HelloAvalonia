using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using HelloAvalonia.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAvalonia;

public class ViewLocator : IDataTemplate
{
    public Control Build(object data)
    {
        var name = data.GetType().FullName!.Replace("ViewModel", "View");
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Program.Container.GetRequiredService(type);
        }
            
        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object data)
    {
        return data is ViewModelBase;
    }
}