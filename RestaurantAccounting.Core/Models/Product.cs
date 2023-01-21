namespace RestaurantAccounting.Core.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Cost { get; set; }

    public TimeSpan? TimeToCook { get; set; }
}
