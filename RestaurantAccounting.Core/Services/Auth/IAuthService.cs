using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Auth;

public interface IAuthService
{
    Employee Authenticate(string login, string password);
}