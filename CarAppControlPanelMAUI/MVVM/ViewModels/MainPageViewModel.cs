using CarAppControlPanelMAUI.MVVM.Pages;
using CarAppControlPanelMAUI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarAppControlPanelMAUI.MVVM.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        
        [RelayCommand]
        async Task NavigateToManageCar()
        {
            await Shell.Current.GoToAsync(nameof(ManageCarPage));
        }

        [RelayCommand]
        async Task NavigateToSettingsPage()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

    }

}
