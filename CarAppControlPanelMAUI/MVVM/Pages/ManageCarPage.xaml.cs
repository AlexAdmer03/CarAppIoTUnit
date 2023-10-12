
using CarAppControlPanelMAUI.MVVM.ViewModels;

namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarPage : ContentPage
{
	public ManageCarPage(ManageCarViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

}