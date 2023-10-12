using CarAppControlPanelMAUI.MVVM.Pages;
using CarAppControlPanelMAUI.Pages;

namespace CarAppControlPanelMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(ManageCarPage), typeof(ManageCarPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }

    }
}