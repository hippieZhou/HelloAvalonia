using Avalonia.Controls;
using HelloAvalonia.ViewModels;

namespace HelloAvalonia.Services;

public interface IDialogService
{
    void Show<TViewModel>(Window owner) where TViewModel : ViewModelBase;
}