using CarAppControlPanelMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace CarAppControlPanelMAUI.MVVM.ViewModels
{
    public partial class ManageCarViewModel : ObservableObject
    {
        public static ManageCarViewModel Instance { get; } = new ManageCarViewModel();
        public ManageCarViewModel()
        {
            isLocked = true;
        }

        private readonly IServiceProvider _serviceProvider;
        private readonly Services.DateAndTimeService _dateAndTimeService;
        private readonly Services.WeatherService _weatherService;

        //LOCKMECHANISM-----------------------------------
        private bool isLocked;
        public bool IsLocked
        {
            get => isLocked;
            set => SetProperty(ref isLocked, value);
        }
        public string LockIcon => IsLocked ? "\uf023" : "\uf3c1";

        public ICommand LockCommand => new Command(Lock);
        public ICommand UnlockCommand => new Command(Unlock);

        private void Lock()
        {
            IsLocked = true;
        }

        private void Unlock()
        {
            IsLocked = false;
        }
        //-----------------------------------
        public ManageCarViewModel(IServiceProvider serviceProvider, DateAndTimeService dateAndTimeService, WeatherService weatherService)
        {
            _serviceProvider = serviceProvider;
            _dateAndTimeService = dateAndTimeService;
            _weatherService = weatherService;

            UpdateDateAndTime();
            UpdateWeather();
        }


        [ObservableProperty]
        private string _miles = "271";
        [ObservableProperty]
        private string _currentTime = "--";
        [ObservableProperty]
        private string _currentDate;
        [ObservableProperty]
        private string _currentWeatherCondition = "\ue137";
        [ObservableProperty]
        private string _currentTemperature = "--";
        [ObservableProperty]
        private string _currentTemperatureUnit = "°C";

        private void UpdateDateAndTime()
        {
            _dateAndTimeService.TimeUpdated += () =>
            {
                CurrentDate = _dateAndTimeService.CurrentDate;
                CurrentTime = _dateAndTimeService.CurrentTime;
            };
        }

        private void UpdateWeather()
        {
            _dateAndTimeService.TimeUpdated += () =>
            {
                CurrentWeatherCondition = _weatherService.CurrentWeatherCondition;
                CurrentTemperature = _weatherService.CurrentTemperature;
            };
        }
    }

}
