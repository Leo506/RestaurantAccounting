using System.Security.Authentication;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Auth;

public partial class InMemoryAuthService : IAuthService
{
    private static readonly Dictionary<(string, string), Employee> Users = new()
    {
        [("test", "password")] = new Employee()
        {
            Login = "test",
            FirstName = "Test",
            LastName = "Testov",
            PersonalShiftStatus = ShiftStatus.Close
        },
        [("test2", "password2")] = new Employee()
        {
            Login = "test2",
            FirstName = "Test2",
            LastName = "Testov2",
            PersonalShiftStatus = ShiftStatus.Close
        }
    };

    public Employee Authenticate(string login, string password)
    {
        return Users.TryGetValue((login, password), out var user)
            ? user
            : throw new AuthenticationException("Incorrect login or password");
    }

    public Task<Employee> AuthenticateAsync(string login, string password)
    {
        return Task.FromResult(Authenticate(login, password));
    }
}