using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Extensions;

public static class NavigationServiceExtension
{
    public static async Task<bool> NavigateIfHavePermission<TViewModel>(this IMvxNavigationService navigation, Employee employee,
        string permission) where TViewModel : IMvxViewModel
    {
        if (employee.EmployeePermissions.FirstOrDefault(x => x.PermissionCode == permission) is null)
            return false;

        return await navigation.Navigate<TViewModel>();
    }

    public static async Task<bool> NavigateIfHavePermission<TViewModel, TParameter>(this IMvxNavigationService navigation,
        Employee employee, string permission, TParameter parameter) where TViewModel : IMvxViewModel<TParameter>
    {
        if (employee.EmployeePermissions.FirstOrDefault(x => x.PermissionCode == permission) is null)
            return false;

        return await navigation.Navigate<TViewModel, TParameter>(parameter);
    }
}