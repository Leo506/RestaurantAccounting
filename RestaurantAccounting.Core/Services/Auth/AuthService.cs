using System.Security.Authentication;
using Microsoft.EntityFrameworkCore;
using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Utils;

namespace RestaurantAccounting.Core.Services.Auth;

public class AuthService : IAuthService
{
    private readonly EmployeeContext _context;

    private const string AuthErrorMessage = "Incorrect login or password";

    public AuthService(EmployeeContext context)
    {
        _context = context;
    }

    public Employee Authenticate(string login, string password)
    {
        password = PasswordEncryptor.EncryptPassword(password);
        return _context.Employees.FirstOrDefault(x => x.Login == login && x.Password == password) ??
               throw new AuthenticationException(AuthErrorMessage);
    }

    public async Task<Employee> AuthenticateAsync(string login, string password)
    {
        password = PasswordEncryptor.EncryptPassword(password);
        return await _context.Employees.FirstOrDefaultAsync(x => x.Login == login && x.Password == password) ??
               throw new AuthenticationException(AuthErrorMessage);
    }
}