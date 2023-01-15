using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Extensions;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.Register;

namespace RestaurantAccounting.Core.ViewModels;

public class RegistrationViewModel : MvxViewModel
{
    public string Login
    {
        get => _employee.Login;
        set
        {
            _employee.Login = value;
            RaisePropertyChanged(() => Login);
            _registrationCommand?.RaiseCanExecuteChanged();
        }
    }

    public string Password
    {
        get => _employee.Password;
        set
        {
            _employee.Password = value;
            RaisePropertyChanged(() => Password);
            _registrationCommand?.RaiseCanExecuteChanged();
        }
    }

    public string FirstName
    {
        get => _employee.FirstName;
        set
        {
            _employee.FirstName = value;
            RaisePropertyChanged(() => FirstName);
            _registrationCommand?.RaiseCanExecuteChanged();
        }
    }

    public string LastName
    {
        get => _employee.LastName;
        set
        {
            _employee.LastName = value;
            RaisePropertyChanged(() => LastName);
            _registrationCommand?.RaiseCanExecuteChanged();
        }
    }

    private MvxCommand? _registrationCommand;

    public ICommand RegistrationCommand => _registrationCommand ??= new MvxCommand(execute: async () =>
        {
            using (_logger.BeginScopeWithCorrelationId())
            {
                try
                {
                    await _registrationService.RegisterAsync(_employee);
                }
                catch (Exception e)
                {
                    _logger.LogError("Failed to register new employee");
                }
            }
        },
        // TODO replace bu more complex validation
        canExecute: () => string.IsNullOrWhiteSpace(Login) is false && string.IsNullOrWhiteSpace(Password) is false &&
                          string.IsNullOrWhiteSpace(FirstName) is false && string.IsNullOrWhiteSpace(LastName) is false);

    private readonly Employee _employee = new();

    private readonly IRegistrationService _registrationService;

    private readonly ILogger<RegistrationViewModel> _logger;


    public RegistrationViewModel(IRegistrationService registrationService, ILogger<RegistrationViewModel> logger)
    {
        _registrationService = registrationService;
        _logger = logger;
    }
}