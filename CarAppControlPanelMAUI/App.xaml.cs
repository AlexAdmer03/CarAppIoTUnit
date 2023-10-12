using CarAppControlPanelMAUI.Services;
using Microsoft.Extensions.Hosting;

namespace CarAppControlPanelMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}





    
