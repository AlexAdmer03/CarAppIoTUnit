
using CarAppControlPanelMAUI.MVVM.ViewModels;

namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarPage : ContentPage
{
    private bool isRotating = false;
    private readonly ManageCarViewModel _viewmodel;
    public ManageCarPage(ManageCarViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
        _viewmodel = viewModel;
    }

    
    private void OnIconTapped(object sender, EventArgs e)
    {
        var viewModel = (ManageCarViewModel)BindingContext;
        viewModel.ToggleState();

        isRotating = !isRotating;
        if (isRotating)
        {
            _ = RotateIcon(); 
        }
    }

    private async Task RotateIcon()
    {
        while (isRotating)
        {
            await FanIcon.RelRotateTo(360, 1500);
        }
    }

}