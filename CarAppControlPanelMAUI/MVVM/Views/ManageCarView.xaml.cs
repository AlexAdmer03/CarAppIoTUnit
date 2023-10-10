namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarView : ContentPage
{
	public ManageCarView()
	{
        InitializeComponent();
    }

    void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

}