using RestaurantAccounting.Core.DbContexts;
using RestaurantAccounting.Core.Models;

namespace RestaurantAccounting.Core.Services;

public static class DbFiller
{
    public static void FillDb(EmployeeContext context)
    {
        if (context.Permissions.Any() is false)
            context.Permissions.AddRange(new Permission()
            {
                PermissionCode = PermissionConstants.PermissionToSeeActiveProducts,
                Description = "Permission to see active products"
            });

        if (context.Products.Any() is false)
            context.Products.AddRange(new()
            {
                ProductName = "Каша",
                Cost = 100,
                TimeToCook = TimeSpan.FromMinutes(10)
            }, new()
            {
                ProductName = "Макароны",
                Cost = 200.5M,
                TimeToCook = TimeSpan.FromMinutes(20)
            }, new()
            {
                ProductName = "Рис",
                Cost = 149.39M,
                TimeToCook = TimeSpan.FromMinutes(23)
            }, new()
            {
                ProductName = "Рыба",
                Cost = 133,
                TimeToCook = TimeSpan.FromHours(1)
            });

        context.SaveChanges();
    }
}