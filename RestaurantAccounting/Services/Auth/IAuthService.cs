using RestaurantAccounting.Models;

namespace RestaurantAccounting.Services.Auth;

public interface IAuthService
{
    UserModel Authenticate(string login, string password);
}