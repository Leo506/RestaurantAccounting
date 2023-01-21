using Microsoft.EntityFrameworkCore;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.ProductService;

public class ProductService : IProductService
{
    private readonly EmployeeContext _context;

    public ProductService(EmployeeContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public List<Product> Get(Func<Product, bool> predicate)
    {
        return _context.Products.Where(predicate).ToList();
    }
}