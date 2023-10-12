using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarAppControlPanelMAUI.MVVM.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.Navigation.PopAsync();
    }
}
