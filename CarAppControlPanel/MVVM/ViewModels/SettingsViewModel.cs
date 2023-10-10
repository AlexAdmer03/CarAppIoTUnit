//using CommunityToolkit.Mvvm.ComponentModel;
//using CommunityToolkit.Mvvm.Input;
//using Microsoft.Extensions.DependencyInjection;
//using System;

//namespace CarAppControlPanel.MVVM.ViewModels
//{
//    public partial class SettingsViewModel : ObservableObject
//    {

//        private readonly IServiceProvider _serviceProvider;

//        public SettingsViewModel(IServiceProvider serviceProvider)
//        {
//            _serviceProvider = serviceProvider;
//        }

//        [ObservableProperty]
//        private string? _title = "Settings";
//        [ObservableProperty]
//        private ObservableObject? _currentContentViewModel;
//        [RelayCommand]
//        private void ExilApplication()
//        {
//            Environment.Exit(0);
//        }
//        [RelayCommand]
//        private void NavigateToHome()
//        {
//            var mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();
//            mainWindowViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
//        }
//        [RelayCommand]
//        private void ShowAddCar()
//        {

//        }
//        [RelayCommand]
//        private void ShowCarList()
//        {

//        }
//        [RelayCommand]
//        private void ShowConfiguration()
//        {

//        }
//    }
//}
