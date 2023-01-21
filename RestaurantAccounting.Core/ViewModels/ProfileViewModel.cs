using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.ViewModels;

public class ProfileViewModel : MvxViewModel<Employee>
{
    public string Login => _employee.Login;

    public string FirstName => _employee.FirstName;

    public string LastName => _employee.LastName;

    public string PersonalShiftStatus
    {
        get => _employee.ShiftStatus;
        set => _employee.ShiftStatus = value;
    }

    private string? _openShiftText = default!;
    public string OpenShiftText
    {
        get => _openShiftText ??= _employee.PersonalShiftStatus == ShiftStatus.Close ? "Close shift" : "Open shift";
        set
        {
            _openShiftText = value;
            RaisePropertyChanged(() => OpenShiftText);
        }
    }

    private MvxCommand? _backCommand;
    public ICommand BackCommand => _backCommand ??= new MvxCommand(() => _navigationService.Close(this));

    private Employee _employee = default!;
    private readonly ILogger<ProfileViewModel> _logger;
    private readonly IMvxNavigationService _navigationService;

    public ProfileViewModel(ILogger<ProfileViewModel> logger, IMvxNavigationService navigationService)
    {
        _logger = logger;
        _navigationService = navigationService;
    }

    public override void Prepare(Employee parameter)
    {
        _employee = parameter;
    }
}