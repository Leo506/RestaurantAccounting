using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services.Register;

public class RegistrationService : IRegistrationService
{
    private readonly EmployeeContext _employeeContext;

    public RegistrationService(EmployeeContext employeeContext)
    {
        _employeeContext = employeeContext;
    }

    public void Register(Employee employee)
    {
        _employeeContext.Employees.Add(employee);
        _employeeContext.SaveChanges();
    }

    public async Task RegisterAsync(Employee employee)
    {
        await _employeeContext.Employees.AddAsync(employee);
        await _employeeContext.SaveChangesAsync();
    }
}