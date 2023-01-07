using MvvmCross.ViewModels;
using RestaurantAccounting.Models;

namespace RestaurantAccounting.ViewModels;

public class ProfileViewModel : MvxViewModel<UserModel>
{
    public string Login => _userModel.Login;

    public string FirstName => _userModel.FirstName;

    public string LastName => _userModel.LastName;

    public bool IsPersonalShiftOpen => _userModel.IsPersonalShiftOpen;
    
    private UserModel _userModel = default!;
    
    public override void Prepare(UserModel parameter)
    {
        _userModel = parameter;
    }
}