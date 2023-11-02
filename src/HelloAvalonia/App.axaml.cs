using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HelloAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = Program.Container.GetRequiredService<MainWindow>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}