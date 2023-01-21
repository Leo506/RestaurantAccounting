using Microsoft.EntityFrameworkCore;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.DbContexts;

public sealed partial class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<EmployeePermission> EmployeePermissions { get; set; }

    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("shiftstatus", new[] { "Open", "Close" });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pk");

            entity.ToTable("Employee", "Restaurant");

            entity.HasIndex(e => e.Login, "Employee_Login_key").IsUnique();

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(1000000);
        });

        modelBuilder.Entity<EmployeePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("EmployeePermissions_pk");

            entity.ToTable("EmployeePermissions", "Restaurant");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.PermissionCode).HasMaxLength(25);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeePermissions)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("EmployeePermissions_Employee_null_fk");

            entity.HasOne(d => d.PermissionCodeNavigation).WithMany(p => p.EmployeePermissions)
                .HasForeignKey(d => d.PermissionCode)
                .HasConstraintName("EmployeePermissions_Permissions_null_fk");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionCode).HasName("Permissions_pk");

            entity.ToTable("Permissions", "Restaurant");

            entity.Property(e => e.PermissionCode).HasMaxLength(25);
            entity.Property(e => e.Description).HasMaxLength(150);
        });
        modelBuilder.HasSequence("Id", "Restaurant");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
