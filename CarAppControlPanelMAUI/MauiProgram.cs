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
                    fonts.AddFont("fa-solid-900.ttf", "FAsolid");
                    fonts.AddFont("fa-thin-100.ttf", "FAthin");
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}