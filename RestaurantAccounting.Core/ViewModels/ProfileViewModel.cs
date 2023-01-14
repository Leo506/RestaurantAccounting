using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.ViewModels;

public class ProfileViewModel : MvxViewModel<UserModel>
{
    public string Login => _userModel.Login;

    public string FirstName => _userModel.FirstName;

    public string LastName => _userModel.LastName;

    public bool IsPersonalShiftOpen
    {
        get => _userModel.IsPersonalShiftOpen;
        set
        {
            _userModel.IsPersonalShiftOpen = value;
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
    
    private UserModel _userModel = default!;
    private readonly ILogger<ProfileViewModel> _logger;

    public ProfileViewModel(ILogger<ProfileViewModel> logger)
    {
        _logger = logger;
    }

    public override void Prepare(UserModel parameter)
    {
        _userModel = parameter;
    }
}