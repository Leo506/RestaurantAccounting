using System.Windows.Controls;
using MvvmCross.Platforms.Wpf.Views;
using RestaurantAccounting.Core.ViewModels;

namespace RestaurantAccounting.WPF.Pages;

public partial class ProductsPage : MvxWpfView<ProductsViewModel>
{
    public ProductsPage()
    {
        InitializeComponent();
    }
}