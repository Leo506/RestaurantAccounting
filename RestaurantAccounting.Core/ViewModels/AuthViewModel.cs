using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Interactions;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.Auth;

namespace RestaurantAccounting.Core.ViewModels;

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

    #region AuthCommand
    private ICommand? _authCommand;
    public ICommand AuthCommand => _authCommand ??= new MvxCommand(async () =>
    {
        _logger.LogInformation("Try to authenticate user");
        try
        {
            var user = await _authService.AuthenticateAsync(Login, Password);
            _logger.LogInformation($"User successfully authenticated. Navigate to {nameof(ProfileViewModel)}");
            await _navigationService.Navigate<MainViewModel, Employee>(user);
        }
        catch (Exception e)
        {
            _logger.LogError("Failed to authenticate user");
            _alert.Alert(e.Message, "Authentication failed", AlertType.Error);
        }
    });
    #endregion

    #region NavigateToRegistration
    private MvxCommand? _navigateToRegistrationCommand;
    public ICommand NavigateToRegistration => _navigateToRegistrationCommand ??=
        new MvxCommand(() => _navigationService.Navigate<RegistrationViewModel>());
    #endregion
    
    private readonly IAuthService _authService;
    private readonly IMvxNavigationService _navigationService;
    private readonly ILogger<AuthViewModel> _logger;
    private readonly IAlertInteraction _alert;

    public AuthViewModel(IAuthService authService, IMvxNavigationService navigationService,
        ILogger<AuthViewModel> logger, IAlertInteraction alert)
    {
        _authService = authService;
        _navigationService = navigationService;
        _logger = logger;
        _alert = alert;
    }
}