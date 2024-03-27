using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

using MAP.Helpers;
using MAP.ViewModels;
using MAP.Services;

namespace MAP
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
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			builder.Services.AddTransient<MainPageViewModel>();
			builder.Services.AddTransient<ICalculatorService, CalculatorService>();

			MauiApp app = builder.Build();
			ServiceHelper.SetServiceProvider(app.Services);

			return app;
		}
	}
}
