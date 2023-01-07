using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxContentPresentation]
[MvxViewFor(typeof(AuthViewModel))]
public partial class AuthPage : MvxWpfView
{
    public AuthPage()
    {
        InitializeComponent();
    }
}