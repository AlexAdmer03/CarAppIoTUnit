using CarAppControlPanelMAUI.Pages;

namespace CarAppControlPanelMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManageCarView), typeof(ManageCarView));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }

    }
}