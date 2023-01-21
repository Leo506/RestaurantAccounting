namespace RestaurantAccounting.Core.Models;

public partial class EmployeePermission
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string PermissionCode { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Permission PermissionCodeNavigation { get; set; } = null!;
}
