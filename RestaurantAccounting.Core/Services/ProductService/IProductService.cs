using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.ProductService;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();

    List<Product> GetAll();

    List<Product> Get(Func<Product, bool> predicate);
}