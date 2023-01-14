using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.DbContexts;

public partial class EmployeeContext : DbContext
{
    private readonly string _connectionString;
    
    public EmployeeContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options, string connectionString)
        : base(options)
    {
        _connectionString = connectionString;
    }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("shiftstatus", new[] { "Open", "Close" });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pk");

            entity.ToTable("Employee", "Restaurant");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Login).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
