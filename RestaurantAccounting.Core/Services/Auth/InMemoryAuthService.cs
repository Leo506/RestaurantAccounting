using System.Security.Authentication;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Auth;

public class InMemoryAuthService : IAuthService
{
    private readonly Dictionary<(string, string), UserModel> _users = new()
    {
        [("test", "password")] = new UserModel()
        {
            Login = "test",
            FirstName = "Test",
            LastName = "Testov",
            IsPersonalShiftOpen = false
        },
        [("test2", "password2")] = new UserModel()
        {
            Login = "test2",
            FirstName = "Test2",
            LastName = "Testov2",
            IsPersonalShiftOpen = false
        }
    };

    public UserModel Authenticate(string login, string password)
    {
        return _users.TryGetValue((login, password), out var user)
            ? user
            : throw new AuthenticationException("Incorrect login or password");
    }
}