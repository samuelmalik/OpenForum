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

	// test OnAppearing overloadu

    /*protected override void OnAppearing()
    {
		LoginViewModel viewModel = BindingContext as LoginViewModel;
		viewModel.ShowErrorMessage = true;
        base.OnAppearing();
    }*/


}

