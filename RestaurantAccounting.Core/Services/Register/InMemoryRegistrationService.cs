using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.Register;

namespace RestaurantAccounting.Core.Services.Auth;

public partial class InMemoryAuthService : IRegistrationService
{
    public void Register(Employee employee)
    {
        Users.Add((employee.Login, employee.Password), employee);
    }

    public Task RegisterAsync(Employee employee)
    {
        Users.Add((employee.Login, employee.Password), employee);
        return Task.CompletedTask;
    }

    public Task AddPermission(Employee employee, string permissionCode)
    {
        throw new NotImplementedException();
    }
}