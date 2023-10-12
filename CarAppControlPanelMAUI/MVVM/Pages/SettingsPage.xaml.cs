using CarAppControlPanelMAUI.MVVM.ViewModels;

namespace CarAppControlPanelMAUI.MVVM.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}