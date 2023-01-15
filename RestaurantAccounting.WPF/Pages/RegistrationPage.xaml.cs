using System.Windows;
using System.Windows.Controls;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxViewFor(typeof(RegistrationViewModel))]
public partial class RegistrationPage : MvxWpfView<RegistrationViewModel>
{
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        ViewModel.Password = (sender as PasswordBox)!.Password;
    }
}