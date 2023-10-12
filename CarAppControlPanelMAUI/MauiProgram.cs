using CarAppControlPanelMAUI.MVVM.ViewModels;
using CarAppControlPanelMAUI.Pages;
using CarAppControlPanelMAUI.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
            builder.Services.AddTransient<ManageCarView>();
            builder.Services.AddTransient<ManageCarViewModel>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();


            builder.Services.AddSingleton<DateAndTimeService>();
            builder.Services.AddSingleton<WeatherService>();
            



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}