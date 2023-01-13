using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Auth;

public interface IAuthService
{
    UserModel Authenticate(string login, string password);
}