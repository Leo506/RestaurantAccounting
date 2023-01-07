using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RestaurantAccounting.Interactions;
using RestaurantAccounting.Services.Auth;

namespace RestaurantAccounting.ViewModels;

public class AuthViewModel : MvxViewModel
{
    #region Login
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
    #endregion
    
    #region Password
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
    #endregion

    #region AuthFailedInteraction
    private MvxInteraction<AlertInteraction> _authFailedInteraction = new();
    public IMvxInteraction<AlertInteraction> AuthFailedInteraction => _authFailedInteraction;
    #endregion
    
    #region AuthCommand
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
            var request = new AlertInteraction() { Message = e.Message };
            _authFailedInteraction.Raise(request);
        }
    });
    #endregion
    
    private IAuthService _authService;
    
    public AuthViewModel(IAuthService authService)
    {
        _authService = authService;
    }
}