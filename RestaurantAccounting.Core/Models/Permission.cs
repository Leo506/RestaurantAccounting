namespace RestaurantAccounting.Core.Models;

public partial class Permission
{
    public string PermissionCode { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<EmployeePermission> EmployeePermissions { get; } = new List<EmployeePermission>();
}
