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

        builder.Services.AddSingleton<QuizPage>();
        builder.Services.AddSingleton<QuizViewModel>();

        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<RegisterViewModel>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<MaterialsPage>();
        builder.Services.AddTransient<MaterialsViewModel>();

        builder.Services.AddSingleton<UsersPage>();
        builder.Services.AddSingleton<UsersViewModel>();
        builder.Services.AddTransient<UsersPage>();
        builder.Services.AddTransient<UsersViewModel>();

        builder.Services.AddSingleton<UserInfoPage>();
        builder.Services.AddSingleton<UserInfoViewModel>();
        builder.Services.AddTransient<UserInfoPage>();
        builder.Services.AddTransient<UserInfoViewModel>();


        return builder.Build();
	}
}
