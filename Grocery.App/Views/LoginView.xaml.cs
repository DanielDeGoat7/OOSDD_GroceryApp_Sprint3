using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private async void OnRegisterClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(RegisterView));
	}
}