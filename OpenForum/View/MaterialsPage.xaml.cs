namespace OpenForum.View;

public partial class MaterialsPage : ContentPage
{
	public MaterialsPage(MaterialsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}