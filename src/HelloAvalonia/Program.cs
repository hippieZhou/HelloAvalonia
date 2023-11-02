using Avalonia;
using System;
using Avalonia.Controls;
using Avalonia.Svg.Skia;
using Avalonia.Xaml.Interactivity;
using CommunityToolkit.Mvvm.DependencyInjection;
using HelloAvalonia.Models;
using HelloAvalonia.Services;
using HelloAvalonia.ViewModels;
using HelloAvalonia.Views;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAvalonia;

class Program
{
    public static IServiceProvider Container => Ioc.Default;

    static Program()
    {
        var container = new Container(cfg =>
        {
            cfg.AddHttpClient();
            cfg.For<ICatsImageService>().Use<CatsImageService>();
            cfg.For<IDialogService>()
                .Use(new DialogService<DialogWindow>(() => new DialogWindow()));
            cfg.Scan(scan =>
            {
                scan.AssemblyContainingType<Program>();
                scan.AddAllTypesOf<ViewModelBase>();
                scan.AddAllTypesOf<Control>();
                scan.WithDefaultConventions();
            });
        });
        Ioc.Default.ConfigureServices(container);
    }
        
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
    {
        GC.KeepAlive(typeof(SvgImageExtension).Assembly);
        GC.KeepAlive(typeof(Avalonia.Svg.Skia.Svg).Assembly);
        GC.KeepAlive(typeof(Interaction));
            
        return AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
    }
}