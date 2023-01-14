using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Auth;

public class AuthService : IAuthService
{
    private readonly EmployeeContext _context;

    public AuthService(EmployeeContext context)
    {
        _context = context;
    }

    public Employee Authenticate(string login, string password)
    {
        return _context.Employees.FirstOrDefault(x => x.Login == login && x.Password == password);
    }
}