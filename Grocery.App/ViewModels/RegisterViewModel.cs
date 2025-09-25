using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System;

public partial class RegisterViewModel : ObservableObject
{
    private readonly IClientRepository _clientRepository;

    [ObservableProperty] string name;
    [ObservableProperty] string emailAddress;
    [ObservableProperty] string password;
    [ObservableProperty] string message;

    public RegisterViewModel(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    [RelayCommand]
    public void Register()
    {
        try
        {
            var client = new Client(
                id: _clientRepository.GetAll().Count + 1,
                name: Name,
                emailAddress: EmailAddress,
                password: Password // In productie: hash het wachtwoord!
            );
            _clientRepository.Add(client);
            Message = "Registratie gelukt!";
        }
        catch (Exception ex)
        {
            Message = ex.Message;
        }
    }
}