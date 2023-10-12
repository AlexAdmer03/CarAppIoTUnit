using CarAppControlPanelMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CarAppControlPanelMAUI.MVVM.ViewModels
{
    public partial class ManageCarViewModel : ObservableObject
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly DateAndTimeService _dateAndTimeService;
        private readonly WeatherService _weatherService;

        //CHARGINGLOGIC________________________________
        private bool isCharging = true;
        public bool IsCharging
        {
            get => isCharging;
            set => SetProperty(ref isCharging, value);
        }
        public ICommand ToggleChargingCommand => new Command(ToggleCharging);

        private void ToggleCharging()
        {
            IsCharging = !IsCharging;
            OnPropertyChanged(nameof(ChargeIcon));
        }

        public string ChargeIcon => IsCharging ? "\uf0e7" : "\ue0b8";


        //LOCKMECHANISM-----------------------------------
        private bool isLocked;
        public bool IsLocked
        {
            get => isLocked;
            set => SetProperty(ref isLocked, value);
        }
        public string LockIcon => IsLocked ? "\uf023" : "\uf3c1";

        public ICommand ToggleLockCommand => new Command(ToggleLock);

        private void ToggleLock()
        {
            IsLocked = !IsLocked;
            OnPropertyChanged(nameof(LockIcon));
        }
        //-----------------------------------
        public ManageCarViewModel(IServiceProvider serviceProvider, DateAndTimeService dateAndTimeService, WeatherService weatherService)
        {
            _serviceProvider = serviceProvider;
            _dateAndTimeService = dateAndTimeService;
            _weatherService = weatherService;

            UpdateDateAndTime();
            UpdateWeather();

            isLocked = true;
        }


        [ObservableProperty]
        private string _distance = "271";
        [ObservableProperty]
        private string _distanceUnit = "km";
        [ObservableProperty]
        private string _currentTime = "--:--";
        [ObservableProperty]
        private string _currentDate;
        [ObservableProperty]
        private string _interiorTemprature = "--";
        [ObservableProperty]
        private string _currentWeatherCondition = "\uf185";
        [ObservableProperty]
        private string _currentTemperature = "--";
        [ObservableProperty]
        private string _currentTemperatureUnit = "°C";

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }

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
