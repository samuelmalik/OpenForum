using OpenForum.View;

namespace OpenForum;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ForumPage), typeof(ForumPage));
	}
}
