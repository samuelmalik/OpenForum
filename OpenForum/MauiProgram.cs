using Microsoft.Extensions.Logging;
using OpenForum.View;
using OpenForum.ViewModel;

namespace OpenForum;

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
				
				fonts.AddFont("Brands-Regular-400.otf", "FAB");
				fonts.AddFont("Free-Regular-400.otf", "FAR");
				fonts.AddFont("Free-Solid-900.otf", "FAS");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<LoginPage>();

        builder.Services.AddSingleton<ForumViewModel>();
        builder.Services.AddSingleton<ForumPage>();

		builder.Services.AddTransient<ForumPage>();
		builder.Services.AddTransient<ForumViewModel>();

		builder.Services.AddSingleton<RegisterPage>();
		builder.Services.AddSingleton<RegisterViewModel>();

        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<RegisterViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        return builder.Build();
	}
}
