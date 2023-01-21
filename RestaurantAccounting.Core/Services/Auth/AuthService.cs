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
        var user = _context.Employees.FirstOrDefault(x => x.Login == login) ??
                   throw new AuthenticationException(AuthErrorMessage);
        if (PasswordEncryptor.Verify(password, user.Password) is false)
            throw new AuthenticationException(AuthErrorMessage);
        
        return user;
    }

    public async Task<Employee> AuthenticateAsync(string login, string password)
    {
        var user = await _context.Employees.FirstOrDefaultAsync(x => x.Login == login) ??
                   throw new AuthenticationException(AuthErrorMessage);
        if (PasswordEncryptor.Verify(password, user.Password) is false)
            throw new AuthenticationException(AuthErrorMessage);

        user.EmployeePermissions = await _context.EmployeePermissions.Where(x => x.EmployeeId == user.Id).ToListAsync();
        
        return user;
    }
}