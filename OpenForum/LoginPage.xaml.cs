using OpenForum.View;
using OpenForum.ViewModel;

namespace OpenForum;

public partial class LoginPage : ContentPage
{
	int count = 0;

	public LoginPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(ForumPage));
    }
}

