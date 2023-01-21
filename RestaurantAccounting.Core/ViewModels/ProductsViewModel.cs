using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.ProductService;

namespace RestaurantAccounting.Core.ViewModels;

public class ProductsViewModel : MvxViewModel
{
    private MvxCommand? _backCommand;
    public ICommand BackCommand => _backCommand ??= new MvxCommand(() => _navigationService.Close(this));
    
    public MvxObservableCollection<Product> Products { get; private set; }

    private readonly IProductService _productService;
    private readonly IMvxNavigationService _navigationService;

    public ProductsViewModel(IProductService productService, IMvxNavigationService navigationService)
    {
        _productService = productService;
        _navigationService = navigationService;
        var tmp = _productService.GetAll();
        Products = new MvxObservableCollection<Product>(_productService.GetAll());
    }
}