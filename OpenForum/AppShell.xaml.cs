using OpenForum.View;

namespace OpenForum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ForumPage), typeof(ForumPage));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(MaterialsPage), typeof(MaterialsPage));
        Routing.RegisterRoute(nameof(QuizPage), typeof(QuizPage));
        Routing.RegisterRoute(nameof(UsersPage), typeof(UsersPage));
        Routing.RegisterRoute(nameof(UserInfoPage), typeof(UserInfoPage));
        Routing.RegisterRoute(nameof(UserDetailsPage), typeof(UserDetailsPage));


    }
}
