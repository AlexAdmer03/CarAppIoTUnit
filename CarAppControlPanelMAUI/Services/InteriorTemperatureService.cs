using System.Timers;
using Timer = System.Timers.Timer;


namespace CarAppControlPanelMAUI.Services
{
    public class InteriorTemperatureService
    {
        private readonly Timer _timer;
        public event Action InteriorTemperatureUpdated;
        private readonly Random _random;

        public string CurrentInteriorTemperature { get; private set; }

        public InteriorTemperatureService()
        {
            _random = new Random();
            _timer = new Timer(60000 * 5);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                CurrentInteriorTemperature = _random.Next(19, 26).ToString();
            }
            catch 
            {
                CurrentInteriorTemperature = "--";
            }
            InteriorTemperatureUpdated?.Invoke();
        }
    }

}
