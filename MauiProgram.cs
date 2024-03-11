using Microsoft.Extensions.Logging;
using YGOSearcher.View;
using YGOSearcher.ViewModels;

namespace YGOSearcher
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPageView>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<AboutView>();
            builder.Services.AddSingleton<AboutViewModel>();

            builder.Services.AddTransient<CardDetailsView>();
            builder.Services.AddTransient<CardDetailsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
