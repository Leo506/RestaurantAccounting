namespace RestaurantAccounting.Core.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ShiftStatus { get; set; } = null!;

    public virtual ICollection<EmployeePermission> EmployeePermissions { get; } = new List<EmployeePermission>();
}
