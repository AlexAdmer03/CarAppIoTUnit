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
        private readonly InteriorTemperatureService _interiorTemperatureService;

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
        public ManageCarViewModel(IServiceProvider serviceProvider, DateAndTimeService dateAndTimeService,
            WeatherService weatherService, InteriorTemperatureService interiorTemperatureService)
        {
            _serviceProvider = serviceProvider;
            _dateAndTimeService = dateAndTimeService;
            _weatherService = weatherService;
            _interiorTemperatureService = interiorTemperatureService;


            UpdateDateAndTime();
            UpdateWeather();
            UpdateInteriorTemperature();

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
        private string _interiorTemperature;
        [ObservableProperty]
        private string _currentWeatherCondition = "\uf185";
        [ObservableProperty]
        private string _currentTemperature = "--";
        [ObservableProperty]
        private string _currentTemperatureUnit = "°C";
        [ObservableProperty]
        private int _leftFanTemperature = 20;
        [ObservableProperty]
        private int _rightFanTemperature = 20;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        //FANFUNCTIONS____________
        //LEFT
        public ICommand IncreaseLeftTemperatureCommand => new RelayCommand(IncreaseLeftTemperature);
        public ICommand DecreaseLeftTemperatureCommand => new RelayCommand(DecreaseLeftTemperature);

        private void IncreaseLeftTemperature()
        {
            if (_leftFanTemperature < 30)
                LeftFanTemperature++;
        }

        private void DecreaseLeftTemperature()
        {
            if (_leftFanTemperature > 16)
                LeftFanTemperature--;
        }

        //_______RIGHT FAN________
        public ICommand IncreaseRightTemperatureCommand => new RelayCommand(IncreaseRightTemperature);
        public ICommand DecreaseRightTemperatureCommand => new RelayCommand(DecreaseRightTemperature);

        private void IncreaseRightTemperature()
        {
            if (_rightFanTemperature < 30)
                RightFanTemperature++;
        }

        private void DecreaseRightTemperature()
        {
            if (_rightFanTemperature > 16)
                RightFanTemperature--;
        }

        //_____________
        private void UpdateDateAndTime()
        {
            _dateAndTimeService.TimeUpdated += () =>
            {
                CurrentDate = _dateAndTimeService.CurrentDate;
                CurrentTime = _dateAndTimeService.CurrentTime;
            };
        }

        private void UpdateInteriorTemperature()
        {
            _interiorTemperatureService.InteriorTemperatureUpdated += () =>
            {
                InteriorTemperature = _interiorTemperatureService.CurrentInteriorTemperature;
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
