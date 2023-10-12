
using CarAppControlPanelMAUI.MVVM.ViewModels;

namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarView : ContentPage
{
	public ManageCarView(ManageCarViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

}