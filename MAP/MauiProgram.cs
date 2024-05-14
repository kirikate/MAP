using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

using MAP.Helpers;
using MAP.ViewModels;
using MAP.Services;

namespace MAP
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp(Func<IServiceProvider, object?, Page>? factory = null, Type? vmPopupType = null)
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services.AddTransient<MainPageViewModel>();
			builder.Services.AddTransient<ICalculatorService, CalculatorService>();

			if (factory != null)
			{
				builder.Services.AddKeyedTransient<Page>("Lab2Popup", factory);
				builder.Services.AddTransient(vmPopupType);
			}

			builder.Services.AddSingleton<IThemeService, ThemeService>();

			MauiApp app = builder.Build();
			ServiceHelper.SetServiceProvider(app.Services);

			return app;
		}
	}
}
