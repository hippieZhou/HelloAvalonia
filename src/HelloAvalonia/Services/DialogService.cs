using Avalonia.Controls;
using HelloAvalonia.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAvalonia.Services;

internal sealed class DialogService<TView> : IDialogService where TView : Window
{
    private readonly Func<TView> _viewFactory;

    public DialogService(Func<TView> viewFactory)
    {
        _viewFactory = viewFactory;
    }

    public void Show<TViewModel>(Window owner) where TViewModel : ViewModelBase
    {
        var view = _viewFactory();
        var viewModel = Program.Container.GetRequiredService<TViewModel>();
        view.DataContext = viewModel;
        view.ShowDialog(owner);
    }
}