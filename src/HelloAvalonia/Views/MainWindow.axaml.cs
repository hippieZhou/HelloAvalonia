using HelloAvalonia.Services;
using HelloAvalonia.ViewModels;
using Lamar;

namespace HelloAvalonia.Views;

public partial class MainWindow : WindowBase<MainWindowViewModel>
{
    [SetterProperty] 
    public IDialogService? DialogService { get; set; }

    public MainWindow()
    {
        InitializeComponent();
    }

    
    public Action ShowDialogInteraction => () => DialogService.Show<DialogWindowViewModel>(this);
}