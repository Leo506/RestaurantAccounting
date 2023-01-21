using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;
using RestaurantAccounting.Core.Utils;

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
        employee.Password = PasswordEncryptor.EncryptPassword(employee.Password);
        _employeeContext.Employees.Add(employee);
        _employeeContext.SaveChanges();
    }

    public async Task RegisterAsync(Employee employee)
    {
        employee.Password = PasswordEncryptor.EncryptPassword(employee.Password);
        await _employeeContext.Employees.AddAsync(employee);
        await _employeeContext.SaveChangesAsync();
    }

    public async Task AddPermission(Employee employee, string permissionCode)
    {
        await _employeeContext.EmployeePermissions.AddAsync(new EmployeePermission()
        {
            EmployeeId = employee.Id,
            PermissionCode = permissionCode
        });
        await _employeeContext.SaveChangesAsync();
    }
}