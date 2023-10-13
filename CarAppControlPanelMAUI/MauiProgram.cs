using CarAppControlPanelMAUI.MVVM.Pages;
using CarAppControlPanelMAUI.MVVM.ViewModels;
using CarAppControlPanelMAUI.Pages;
using CarAppControlPanelMAUI.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedLibrary.Models.Devices;
using SharedLibrary.Services;

namespace CarAppControlPanelMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-light-300.ttf", "FAlight");
                    fonts.AddFont("fa-regular-400.ttf", "FAregular");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome5Solid");
                    fonts.AddFont("fa-thin-100.ttf", "FAthin");
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                });
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddTransient<SettingsViewModel>();
            builder.Services.AddTransient<ManageCarPage>();
            builder.Services.AddTransient<ManageCarViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            string connectionString = "HostName=AlexA-IoTHub.azure-devices.net;DeviceId=CarFan1000;SharedAccessKey=T+foRO+s2MRjniqZ0fpOSxN+VqamSES08AIoTIVaeU4=";
            builder.Services.AddSingleton(new DeviceConfiguration(connectionString));

            // Registrera DeviceManager
            builder.Services.AddTransient<DeviceManager>();

            builder.Services.AddSingleton<DateAndTimeService>();
            builder.Services.AddSingleton<WeatherService>();
            builder.Services.AddSingleton<InteriorTemperatureService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}