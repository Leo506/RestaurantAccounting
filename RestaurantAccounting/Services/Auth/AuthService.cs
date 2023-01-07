using System.Collections.Generic;
using System.Security.Authentication;
using RestaurantAccounting.Models;

namespace RestaurantAccounting.Services.Auth;

public class AuthService : IAuthService
{
    private readonly Dictionary<(string, string), UserModel> _users = new()
    {
        [("test", "password")] = new UserModel()
        {
            Login = "test",
            IsPersonalShiftOpen = false
        },
        [("test2", "password2")] = new UserModel()
        {
            Login = "test2",
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