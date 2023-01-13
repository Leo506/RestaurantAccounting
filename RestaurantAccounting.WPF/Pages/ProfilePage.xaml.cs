using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

[MvxContentPresentation]
[MvxViewFor(typeof(ProfileViewModel))]
public partial class ProfilePage : MvxWpfView
{
    public ProfilePage()
    {
        InitializeComponent();
    }
}