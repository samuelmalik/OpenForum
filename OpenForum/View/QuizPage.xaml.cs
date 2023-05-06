namespace OpenForum.View;

public partial class QuizPage : ContentPage
{
	public QuizPage(QuizViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}