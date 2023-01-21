using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.ViewModels;

public class MainViewModel : MvxViewModel<Employee>
{
    #region OpenProfileCommand
    private MvxAsyncCommand? _openProfileCommand;
    public ICommand OpenProfileCommand => _openProfileCommand ??= new MvxAsyncCommand(OpenProfile);
    #endregion

    #region OpenProductspage
    private MvxAsyncCommand? _openProductsPage;
    public ICommand OpenProductsPage => _openProductsPage ??= new MvxAsyncCommand(OpenProducts);
    #endregion
    
    private readonly IMvxNavigationService _navigationService;
    private Employee _employee;

    public MainViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    private async Task OpenProfile()
    {
        await _navigationService.Navigate<ProfileViewModel, Employee>(_employee);
    }

    private async Task OpenProducts()
    {
        await _navigationService.Navigate<ProductsViewModel>();
    }

    public override void Prepare(Employee parameter)
    {
        _employee = parameter;
    }
}