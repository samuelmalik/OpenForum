using OpenForum.ViewModel;

namespace OpenForum.View;

public partial class ForumPage : ContentPage
{
	public ForumPage(ForumViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}