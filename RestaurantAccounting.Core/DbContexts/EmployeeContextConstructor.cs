using Microsoft.EntityFrameworkCore;

namespace RestaurantAccounting.Core.DbContexts;

public partial class EmployeeContext
{
    public EmployeeContext()
    {
        Database.EnsureCreated();
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}