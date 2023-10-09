namespace CarAppControlPanelMAUI.Pages;

public partial class ManageCarPage : ContentPage
{
	public ManageCarPage()
	{
		InitializeComponent();
	}

    void OnBackButtonClicked(object sender, EventArgs e)
    {
        // Your back button logic here, for example:
        Navigation.PopAsync();
    }

    void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        double initialY = 0;

        switch (e.StatusType)
        {
            case GestureStatus.Started:
                initialY = LockIcon.TranslationY;
                break;

            case GestureStatus.Running:
               
                LockIcon.TranslationY = Math.Max(0, initialY + e.TotalY);
                break;

            case GestureStatus.Completed:
               
                if (LockIcon.TranslationY > 50)
                {
                    LockIcon.Text = "&#xf3c1;"; 
                    LockIcon.TranslationY = 0; 
                }
                else
                {
                    LockIcon.Text = "&#xf023;"; 
                    LockIcon.TranslationY = 0;  
                }
                break;
        }
    }
}