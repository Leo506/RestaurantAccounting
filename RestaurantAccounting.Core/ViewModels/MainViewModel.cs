using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.ViewModels;

public class MainViewModel : MvxViewModel<Employee>
{
    #region OpenProfileCommand
    private MvxCommand? _openProfileCommand;
    public ICommand OpenProfileCommand => _openProfileCommand ??= new MvxCommand(OpenProfile);
    #endregion

    #region OpenProductspage
    private MvxCommand? _openProductsPage;
    public ICommand OpenProductsPage => _openProductsPage ??= new MvxCommand(OpenProducts);
    #endregion
    
    private readonly IMvxNavigationService _navigationService;
    private Employee _employee;

    public MainViewModel(IMvxNavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    private void OpenProfile()
    {
        _navigationService.Navigate<ProfileViewModel, Employee>(_employee);
    }

    private void OpenProducts()
    {
        _navigationService.Navigate<ProductsViewModel>();
    }

    public override void Prepare(Employee parameter)
    {
        _employee = parameter;
    }
}