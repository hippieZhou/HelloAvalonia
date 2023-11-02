using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HelloAvalonia.Models;
using Lamar;

namespace HelloAvalonia.ViewModels;

public partial class DialogWindowViewModel : ViewModelBase
{
    [SetterProperty] public ICatsImageService  CatsImageService { get; set; }

    [ObservableProperty] private bool _loading;
    [ObservableProperty] private Bitmap? _catImage;
    

    [RelayCommand]
    private async Task Opened()
    {
        Loading = true;
        var a = CatsImageService;
        var bitmap = await CatsImageService.GetRandomImage();
        CatImage = bitmap;
        Loading = false;
    }

    [RelayCommand]
    private void Hide(Action? interaction)
    {
        CatImage = null;
        interaction?.Invoke();
    }
}