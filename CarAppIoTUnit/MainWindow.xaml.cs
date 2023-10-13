using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarAppIoTUnit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard fanStoryboard;
        private readonly DeviceManager _deviceManager;
        public MainWindow(DeviceManager deviceManager)
        {
            InitializeComponent();

            fanStoryboard = (Storyboard)FindResource("FanStoryboard");

            //ÄNDRA FÄRG => ConnectivityStatus.Foreground = Brushes.Blue;
            ConnectivityStatus.Foreground = Brushes.Green;
            ConnectivityStatus.Text = "Connected to Car";

            _deviceManager = deviceManager;
            Task.WhenAll(ToggleLockStateAsync(), ToggleChargeStateAsync(), ToggleFanStateAsync());
            
        }

        public async Task ToggleFanStateAsync()
        {
            Storyboard fan = (Storyboard)FindResource("FanStoryboard");

            while (true)
            {
                if (_deviceManager.AllowSending())
                {
                    fan.Begin();
                }
                else
                {
                    fan.Stop();
                }
                await Task.Delay(1000);
            }
        }

        private void Fan_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                if (button.Content.ToString() == "Turn On")
                {
                    button.Content = "Turn Off";
                    FanStatus.Text = "|  Status: ON  |";
                    MessageBox.Show("Fans turned ON");
                    fanStoryboard.Begin();

                }
                else
                {
                    button.Content = "Turn On";
                    FanStatus.Text = "|  Status: OFF  |";
                    MessageBox.Show("Fans turned OFF");
                    fanStoryboard.Stop();

                }
            }
        }


        private async Task ToggleLockStateAsync()
        {
            if (_deviceManager.AllowSending())
            {
                LockIcon.Text = "\uf023";
            }
            else
            {
                LockIcon.Text = "\uf09c";
            }
        }


        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                if (button.Content.ToString() == "Unlock")
                {
                    button.Content = "Lock";
                    LockStatus.Text = "|  Status: Unlocked  |";
                    MessageBox.Show("Car UNLOCKED");

                    var run = new Run("\uf09c"); // Unicode character for the unlocked icon
                    LockIcon.Inlines.Clear();
                    LockIcon.Inlines.Add(run);
                }
                else
                {
                    button.Content = "Unlock";
                    LockStatus.Text = "|  Status: Locked  |";
                    MessageBox.Show("Car LOCKED");

                    var run = new Run("\uf023"); // Unicode character for the locked icon
                    LockIcon.Inlines.Clear();
                    LockIcon.Inlines.Add(run);
                }
            }
        }


        private async Task ToggleChargeStateAsync()
        {
            if (_deviceManager.AllowSending())
            {
                ChargeIcon.Foreground = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                ChargeIcon.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }


        private void Charge_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null)
            {
                if (button.Content.ToString() == "Resume")
                {
                    button.Content = "Stop";
                    ChargeStatus.Text = "|  Status: Charging  |";
                    MessageBox.Show("Car RESUMED Charging");
                   
                    ChargeIcon.Foreground = new SolidColorBrush(Colors.Yellow);
                }
                else
                {
                    button.Content = "Resume";
                    ChargeStatus.Text = "|  Status: Not Charging  |";
                    MessageBox.Show("Car STOPPED Charging");
                    
                    ChargeIcon.Foreground = new SolidColorBrush(Colors.LightGray);
                }
            }
        }
    }
}
