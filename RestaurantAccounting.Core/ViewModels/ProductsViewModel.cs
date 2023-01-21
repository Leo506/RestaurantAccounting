using MvvmCross.ViewModels;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.ProductService;

namespace RestaurantAccounting.Core.ViewModels;

public class ProductsViewModel : MvxViewModel
{
    public MvxObservableCollection<Product> Products { get; private set; }

    private readonly IProductService _productService;
    
    public ProductsViewModel(IProductService productService)
    {
        _productService = productService;
        var tmp = _productService.GetAll();
        Products = new MvxObservableCollection<Product>(_productService.GetAll());
    }
}