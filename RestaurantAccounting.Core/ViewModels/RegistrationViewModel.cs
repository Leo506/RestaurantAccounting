using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
            try
            {
                await _registrationService.RegisterAsync(_employee);
                await _registrationService.AddPermission(_employee, PermissionConstants.PermissionToSeeActiveProducts);
                await _navigationService.Navigate<AuthViewModel>();
            }
            catch (Exception e)
            {
                _logger.LogError("Failed to register new employee: {E}", e);
            }
        },
        // TODO replace bu more complex validation
        canExecute: () => string.IsNullOrWhiteSpace(Login) is false && string.IsNullOrWhiteSpace(Password) is false &&
                          string.IsNullOrWhiteSpace(FirstName) is false && string.IsNullOrWhiteSpace(LastName) is false);

    private readonly Employee _employee = new()
    {
        PersonalShiftStatus = ShiftStatus.Close
    };
    private readonly IRegistrationService _registrationService;
    private readonly ILogger<RegistrationViewModel> _logger;
    private readonly IMvxNavigationService _navigationService;

    public RegistrationViewModel(IRegistrationService registrationService, ILogger<RegistrationViewModel> logger,
        IMvxNavigationService navigationService)
    {
        _registrationService = registrationService;
        _logger = logger;
        _navigationService = navigationService;
    }
}