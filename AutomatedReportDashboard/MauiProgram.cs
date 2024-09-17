using Blazored.LocalStorage;
using Blazored.Toast;
using MauiApp1.Data;
using MauiApp1.WhatsAppSetting;
using Microsoft.Extensions.Logging;

namespace MauiApp1
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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddSingleton<WhatsAppService>();
            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<SessionService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://adel99.bsite.net") });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
