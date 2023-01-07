using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Interactions;
using RestaurantAccounting.Models;
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
    public ICommand AuthCommand => _authCommand ??= new MvxCommand(async () =>
    {
        using (_logger.BeginScope(new Dictionary<string, object>()
               {
                   ["CorrelationId"] = Guid.NewGuid()
               }))
        {
            _logger.LogInformation("Try to authenticate user");
            try
            {
                var user = _authService.Authenticate(Login, Password);
                _logger.LogInformation($"User successfully authenticated. Navigate to {nameof(ProfileViewModel)}");
                await _navigationService.Navigate<ProfileViewModel, UserModel>(user);
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to authenticate user");
                var request = new AlertInteraction() { Message = e.Message };
                _authFailedInteraction.Raise(request);
            }
        }
    });
    #endregion
    
    private readonly IAuthService _authService;
    private readonly IMvxNavigationService _navigationService;
    private readonly ILogger<AuthViewModel> _logger;

    public AuthViewModel(IAuthService authService, IMvxNavigationService navigationService,
        ILogger<AuthViewModel> logger)
    {
        _authService = authService;
        _navigationService = navigationService;
        _logger = logger;
    }
}