using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.ProductService;

namespace RestaurantAccounting.Core.ViewModels;

public class ProductsViewModel : MvxViewModel
{
    #region BackCommand
    private MvxAsyncCommand? _backCommand;
    public ICommand BackCommand => _backCommand ??= new MvxAsyncCommand(async () => await _navigationService.Close(this));
    #endregion

    private string _searchScope;
    public string SearchScope
    {
        get => _searchScope;
        set
        {
            _searchScope = value;
            Products = string.IsNullOrWhiteSpace(_searchScope)
                ? new MvxObservableCollection<Product>(_productService.GetAll())
                : new MvxObservableCollection<Product>(_productService.Get(x =>
                    x.ProductName.ToLower().Contains(_searchScope.ToLower())));
            
            RaisePropertyChanged(() => Products);
            RaisePropertyChanged(() => SearchScope);
        }
    }
    
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