using System.Timers;
using Timer = System.Timers.Timer;


namespace CarAppControlPanelMAUI.Services
{
    public class InteriorTemperatureService
    {
        private Timer _timer;
        private Random _random;

        public event Action<int> OnTemperatureChanged;

        public InteriorTemperatureService()
        {
            _random = new Random();
            _timer = new Timer(300000);
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            var newTemperature = _random.Next(19, 26);
            OnTemperatureChanged?.Invoke(newTemperature);
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}
