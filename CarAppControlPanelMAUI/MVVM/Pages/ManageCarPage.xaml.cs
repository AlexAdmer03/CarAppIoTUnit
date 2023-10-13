
using CarAppControlPanelMAUI.MVVM.ViewModels;

namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarPage : ContentPage
{
    private bool isRotating = false;
    public ManageCarPage(ManageCarViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void OnIconTapped(object sender, EventArgs e)
    {
        if (isRotating)
        {
            isRotating = false;
            return;
        }

        isRotating = true;
        await RotateIcon();
    }

    private async Task RotateIcon()
    {
        while (isRotating)
        {
            await FanIcon.RelRotateTo(360, 1500);
        }
    }

}