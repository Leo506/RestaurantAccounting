using MvvmCross.Platforms.Wpf.Views;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

public partial class MainPage : MvxWpfView<MainViewModel>
{
    public MainPage()
    {
        InitializeComponent();
    }
}