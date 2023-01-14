using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Services.Register;

namespace RestaurantAccounting.Core.Services.Auth;

public partial class InMemoryAuthService : IRegistrationService
{
    public void Register(Employee employee)
    {
        _users.Add((employee.Login, employee.Password), employee);
    }

    public Task RegisterAsync(Employee employee)
    {
        _users.Add((employee.Login, employee.Password), employee);
        return Task.CompletedTask;
    }
}