using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RestaurantAccounting.Services.Auth;

namespace RestaurantAccounting.ViewModels;

public class AuthViewModel : MvxViewModel
{
    private string _login;
    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            RaisePropertyChanged(() => Login);
        }
    }


    private string _password;
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            RaisePropertyChanged(() => Password);
        }
    }

    private ICommand? _authCommand;

    public ICommand AuthCommand => _authCommand ??= new MvxCommand(() =>
    {
        try
        {
            var user = _authService.Authenticate(Login, Password);
            // TODO navigate to profile
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // TODO show error popup
        }
    });

    private IAuthService _authService;
    
    public AuthViewModel(IAuthService authService)
    {
        _authService = authService;
    }
}