namespace RestaurantAccounting.Models;

public class UserModel
{
    public string Login { get; set; } = default!;
    
    public bool IsPersonalShiftOpen { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
}