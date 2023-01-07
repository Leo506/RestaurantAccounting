using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxViewFor(typeof(AuthViewModel))]
public partial class AuthPage : MvxWpfView
{
    public AuthPage()
    {
        InitializeComponent();
    }
}