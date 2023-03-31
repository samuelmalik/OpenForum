using OpenForum.View;
using OpenForum.ViewModel;

namespace OpenForum;

public partial class LoginPage : ContentPage
{

	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    
}

