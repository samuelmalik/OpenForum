namespace OpenForum.View;

public partial class UsersPage : ContentPage
{
	public UsersPage(UsersViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}