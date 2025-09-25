using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private readonly GlobalViewModel _global;
        private readonly IClientRepository _clientRepository;

        [ObservableProperty]
        private string email = "user3@mail.com";

        [ObservableProperty]
        private string password = "user3";

        [ObservableProperty]
        private string loginMessage;

        public LoginViewModel(IAuthService authService, GlobalViewModel global, IClientRepository clientRepository)
        { //_authService = App.Services.GetServices<IAuthService>().FirstOrDefault();
            _authService = authService;
            _global = global;
            _clientRepository = clientRepository;
        }

        [RelayCommand]
        public async Task Login()
        {
            var client = _clientRepository.Get(Email);
            if (client != null && client.Password == Password) // Gebruik hier eventueel PasswordHelper
            {
                LoginMessage = $"Welkom {client.Name}!";
                _global.Client = client;
                // Succesvol ingelogd
                // Navigatie naar hoofdscherm, bijvoorbeeld:
                await Shell.Current.GoToAsync("//GroceryListsView");
            }
            else
            {
                LoginMessage = "Ongeldige inloggegevens.";
            }
        }
    }
}
