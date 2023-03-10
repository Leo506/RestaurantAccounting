using System.Windows;
using System.Windows.Controls;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Interactions;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxContentPresentation]
[MvxViewFor(typeof(AuthViewModel))]
public partial class AuthPage : MvxWpfView
{
    public AuthPage()
    {
        InitializeComponent();
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        var actualPassword = (sender as PasswordBox)?.Password;
        if (ViewModel is AuthViewModel authViewModel) authViewModel.Password = actualPassword ?? "";
    }
}