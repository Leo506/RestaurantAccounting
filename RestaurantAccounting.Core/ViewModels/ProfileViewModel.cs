using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.ViewModels;

public class ProfileViewModel : MvxViewModel<Employee>
{
    public string Login => _employee.Login;

    public string FirstName => _employee.FirstName;

    public string LastName => _employee.LastName;

    public bool IsPersonalShiftOpen
    {
        get => _employee.ShiftStatus == ShiftStatus.Open;
        set
        {
            _employee.ShiftStatus = value ? ShiftStatus.Open : ShiftStatus.Close;
            RaisePropertyChanged(() => IsPersonalShiftOpen);
        }
    }

    private string? _openShiftText = default!;
    public string OpenShiftText
    {
        get => _openShiftText ??= IsPersonalShiftOpen ? "Close shift" : "Open shift";
        set
        {
            _openShiftText = value;
            RaisePropertyChanged(() => OpenShiftText);
        }
    }

    #region OpenShiftCommand
    private MvxCommand? _openShiftCommand;
    public ICommand OpenShiftCommand =>
        _openShiftCommand ??= new MvxCommand(() =>
        {
            using (_logger.BeginScope(new Dictionary<string, object>() { ["CorrelationId"] = Guid.NewGuid() }))
            {
                if (IsPersonalShiftOpen)
                    _logger.LogInformation("Closing personal shift");
                else
                    _logger.LogInformation("Opening personal shift");
                
                IsPersonalShiftOpen = !IsPersonalShiftOpen;
                OpenShiftText = IsPersonalShiftOpen ? "Close shift" : "Open shift";
            }
        });
    #endregion
    
    private Employee _employee = default!;
    private readonly ILogger<ProfileViewModel> _logger;

    public ProfileViewModel(ILogger<ProfileViewModel> logger)
    {
        _logger = logger;
    }

    public override void Prepare(Employee parameter)
    {
        _employee = parameter;
    }
}