using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Register;

public interface IRegistrationService
{
    void Register(Employee employee);

    Task RegisterAsync(Employee employee);

    Task AddPermission(Employee employee, string permissionCode);
}