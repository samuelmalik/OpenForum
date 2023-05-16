namespace OpenForum.View;
using OpenForum.View;
using OpenForum.ViewModel;
using OpenForum.Model;

public partial class UsersPage : ContentPage
{
	public UsersPage(UsersViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}

    protected override void OnAppearing()
    {
        UsersViewModel viewModel = BindingContext as UsersViewModel;
        viewModel.Users.Clear();
        foreach (var user in User.All)
        {
            viewModel.Users.Add(user);
        }

        if (User.currentUser.IsAdmin == 1)
        {
            viewModel.IsCurrentUserAdmin = true;
        }
        else { viewModel.IsCurrentUserAdmin = false; }
        base.OnAppearing();
    }

    

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        UsersViewModel viewModel = BindingContext as UsersViewModel;
        viewModel.Users.Clear();
        foreach (var user in User.All)
        {
            viewModel.Users.Add(user);
        }

        if (User.currentUser.IsAdmin == 1)
        {
            viewModel.IsCurrentUserAdmin = true;
        }
        else { viewModel.IsCurrentUserAdmin = false; }
        base.OnNavigatedTo(args);
    }
}