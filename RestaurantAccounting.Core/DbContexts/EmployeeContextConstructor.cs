using Microsoft.EntityFrameworkCore;

namespace RestaurantAccounting.Core.DbContexts;

public partial class EmployeeContext
{
    private readonly string _connectionString;

    public EmployeeContext(string connectionString)
    {
        _connectionString = connectionString;
        Database.EnsureCreated();
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options, string connectionString)
        : base(options)
    {
        _connectionString = connectionString;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql(_connectionString);
}